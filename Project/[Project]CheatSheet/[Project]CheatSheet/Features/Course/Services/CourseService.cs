using _Project_CheatSheet.Common.CurrentUser.Interfaces;
using _Project_CheatSheet.Features.Course.Interfaces;
using _Project_CheatSheet.Features.Course.Models;
using _Project_CheatSheet.Infrastructure.Data;
using _Project_CheatSheet.Infrastructure.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace _Project_CheatSheet.Features.Course.Services
{
    public class CourseService : ICourseService
    {
        private const int CoursesPerPage = 12;

        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;

        public CourseService(
            CheatSheetDbContext context,
            IMapper mapper,
            ICurrentUser currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
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

        public async Task<IEnumerable<CourseRespondAllModel>> GetAllCourses(int page)
        {
            page = page - 1;
            var userId = currentUserService.GetUserId();

            //12*1=12-12=0
            var coursesToSkip = page * CoursesPerPage - page;
            var coursesCount = await context.Courses.CountAsync();

            if (coursesToSkip > coursesCount || page < 0)
            {
                return Enumerable.Empty<CourseRespondAllModel>();
            }

            //45 = 3*12=32 
            int resourcesToTake =
                coursesCount - page * CoursesPerPage > CoursesPerPage
                    ? resourcesToTake = CoursesPerPage
                    : resourcesToTake = coursesCount - page * CoursesPerPage;

            var coursesWhereTheUserHasPaid = await context.UserCourses.Select(uc=>new UserCourses()
            {
                UserId = uc.UserId,
                CourseId = uc.CourseId,
            }).Where(u => u.UserId == userId).ToListAsync();

            var courses = await context.Courses
                .ProjectTo<CourseRespondAllModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

            foreach (var course in courses)
            {
                if (coursesWhereTheUserHasPaid.Select(c=>c.CourseId.ToString().ToLower()).Contains(course.Id.ToLower()))
                {
                    course.HasPaid = true;
                }
            }

            return courses;
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
    }
}