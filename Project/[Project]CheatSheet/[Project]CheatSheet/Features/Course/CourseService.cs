namespace _Project_CheatSheet.Features.Course
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.CurrentUser.Interfaces;
    using Common.Pagination;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using Models;
    using static Common.CachingConstants.CachingConstants.Course;

    public class CourseService : ICourseService
    {
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;

        public CourseService(
            CheatSheetDbContext context,
            IMapper mapper,
            ICurrentUser currentUserService,
            IMemoryCache cache)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
            this.cache = cache;
        }


        public async Task<bool> JoinCourse(string id)
        {
            var getUser = await currentUserService.GetUser();
            var getCourse = await context.Courses.FirstOrDefaultAsync(c => c.Id.ToString() == id);


            if (getCourse == null || getUser == null)
            {
                return false;
            }

            var userCourse = new UserCourses
            {
                Course = getCourse,
                CourseId = getCourse.Id,
                User = getUser,
                UserId = getUser.Id
            };

            context.UserCourses.Add(userCourse);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CourseRespondAllModel>> GetAllCourses(int page, CourseRequestQueryModel query)
        {
            var userId = currentUserService.GetUserId();

            var cacheKey = $"Courses_{userId}_{page}_{query.Language}_{query.Price}";
            if (cache.TryGetValue(cacheKey, out IEnumerable<CourseRespondAllModel> cachedResult))
            {
                return cachedResult;
            }

            var result = context.Courses
                .Where(uc => !uc.UsersCourses.Any())
                .ProjectTo<CourseRespondAllModel>(mapper.ConfigurationProvider);


            IEnumerable<CourseRespondAllModel> paginationResult = await Pagination<CourseRespondAllModel>.CreateAsync(result, page);

            if (!string.IsNullOrWhiteSpace(query.Language))
            {
                paginationResult = paginationResult
                    .Where(p => p.Category == query.Language);
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(PublicCoursesCache),
                Priority = CacheItemPriority.Low
            };

            cache.Set(cacheKey, paginationResult, cacheEntryOptions);

            return paginationResult;
        }

        public async Task<IEnumerable<CourseRespondAllModel>> GetMyCourses(int page)
        {
            var userId = currentUserService.GetUserId();

            var cacheKey = $"My_Courses_{userId}_{page}";
            if (cache.TryGetValue(cacheKey, out IEnumerable<CourseRespondAllModel> cachedResult))
            {
                return cachedResult;
            }

            var result = context.Courses
                .Where(uc => uc.UsersCourses.Any(c => c.UserId == userId))
                .ProjectTo<CourseRespondAllModel>(mapper.ConfigurationProvider);

            var paginationResult = await Pagination<CourseRespondAllModel>.CreateAsync(result, page);

            foreach (var course in paginationResult) //Todo think of better way to implement, without the need of yet another class
            {
                course.HasPaid = true;
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(MyCoursesCache),
                Priority = CacheItemPriority.Low
            };

            cache.Set(cacheKey, paginationResult, cacheEntryOptions);

            return paginationResult;
        }

        public async Task<CourseRespondModel> GetCourseDetails(string id)
        {
            var userId = currentUserService.GetUserId();
            var course = await context.Courses
                .Include(u => u.UsersCourses)
                .FirstOrDefaultAsync(c => c.Id.ToString() == id && c.UsersCourses.Any(uc => uc.UserId == userId));

            if (course == null)
            {
                return null;
            }

            return mapper.Map<CourseRespondModel>(course);
        }

        public async Task<CourseRespondPaymentModel> GetPaymentDetails(string id)
        {
            var getCourse = await context.Courses.FirstOrDefaultAsync(c => c.Id.ToString() == id);
            return mapper.Map<CourseRespondPaymentModel>(getCourse);
        }

        public async Task<ICollection<string>> GetCoursesLanguages()
        {
            ICollection<string> languages;
            if (!cache.TryGetValue(nameof(languages), out languages))
            {
                languages = await context.Courses.AsNoTracking().Select(c => c.Category.ToString()).Distinct()
                    .ToArrayAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CategoriesCoursesCache),
                    Priority = CacheItemPriority.Low
                };
                cache.Set(nameof(languages), languages, cacheEntryOptions);
            }

            return languages;
        }
    }
}