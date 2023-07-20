namespace _Project_CheatSheet.Features.Course.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Caching;
    using Common.Pagination;
    using Common.UserService.Interfaces;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using Models;
    using static Common.CachingConstants.CachingConstants.Course;

    public class CourseService : ICourseService
    {
        private readonly IMemoryCache cache;
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;
        private readonly ICacheService setCache;

        public CourseService(
            CheatSheetDbContext context,
            IMapper mapper,
            ICurrentUser currentUserService,
            IMemoryCache cache,
            ICacheService setCache)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
            this.cache = cache;
            this.setCache = setCache;
        }

        public async Task<bool> JoinCourse(string id)
        {
            var getCourse = await context.Courses.FindAsync(id);

            if (getCourse == null)
            {
                return false;
            }

            var userId = currentUserService.GetUserId();

            if (getCourse.UsersCourses.Any(uc => uc.UserId == userId))
            {
                return false;
            }

            var userCourse = new UserCourses
            {
                Course = getCourse,
                CourseId = getCourse.Id,
                UserId = userId
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
                .AsNoTracking()
                .Where(uc => !uc.UsersCourses.Any())
                .ProjectTo<CourseRespondAllModel>(mapper.ConfigurationProvider);

            IEnumerable<CourseRespondAllModel> paginationResult =
                await Pagination<CourseRespondAllModel>.CreateAsync(result, page);

            if (!string.IsNullOrWhiteSpace(query.Language))
            {
                paginationResult = paginationResult
                    .Where(p => p.Category == query.Language);
            }

            setCache.SetCache(cacheKey, paginationResult, PublicCoursesCache);

            return paginationResult;
        }

        public async Task<IEnumerable<CourseRespondAllModel>> GetMyCourses(int page, string? toggle)
        {
            var userId = currentUserService.GetUserId();
            var isArchived = string.IsNullOrWhiteSpace(toggle) || toggle == "true";

            var cacheKey = $"My_Courses_{userId}_{page}_{isArchived}";
            if (cache.TryGetValue(cacheKey, out IEnumerable<CourseRespondAllModel> cachedResult))
            {
                return cachedResult;
            }

            var courseResult = context.Courses
                .AsNoTracking()
                .Where(uc => uc.UsersCourses.Any(c => c.UserId == userId));

            var filteredResults = FilterWhetherArchiveOrNotQuery(isArchived, courseResult);

            var paginationResult = await Pagination<CourseRespondAllModel>.CreateAsync(filteredResults, page);

            foreach (var course in
                     paginationResult) //Todo think of better way to implement, without the need of yet another class
            {
                course.HasPaid = true;
            }

            setCache.SetCache(cacheKey, paginationResult, MyCoursesCache);

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
            var getCourse = await context.Courses.FindAsync(id);
            return mapper.Map<CourseRespondPaymentModel>(getCourse);
        }

        public async Task<ICollection<string>> GetCoursesLanguages()
        {
            var cacheKey = "Course_Languages_";
            if (cache.TryGetValue(cacheKey, out ICollection<string> languages))
            {
                return languages;
            }

            languages = await context.Courses.AsNoTracking().Select(c => c.Category.ToString()).Distinct()
                .ToArrayAsync();

            setCache.SetCache(nameof(languages), languages, CategoriesCoursesCache);

            return languages;
        }

        private IQueryable<CourseRespondAllModel> FilterWhetherArchiveOrNotQuery(bool isArchived,
            IQueryable<Course> courseResult)
        {
            IQueryable<CourseRespondAllModel> filteredResults;
            var currentDate = DateTime.Now;
            if (isArchived)
            {
                filteredResults = courseResult
                    .Where(c => c.EndDate <= currentDate)
                    .ProjectTo<CourseRespondAllModel>(mapper.ConfigurationProvider);
            }
            else
            {
                filteredResults = courseResult
                    .Where(c => c.EndDate > currentDate)
                    .ProjectTo<CourseRespondAllModel>(mapper.ConfigurationProvider);
            }

            return filteredResults;
        }
    }
}