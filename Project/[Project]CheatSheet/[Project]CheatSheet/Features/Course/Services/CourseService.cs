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

        public async Task<IEnumerable<CourseRespondAllModel>> GetAllCourses()
        {
            return await context.Courses.ProjectTo<CourseRespondAllModel>(mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<CourseRespondModel> GetCourseDetails(string id)
        {
            var userId = currentUserService.GetUserId();
            var course = await context.Courses
                .Include(c=>c.UsersCourses)
                    .Take(1)
                .Include(c=>c.Topics)
                    .Take(1)
                .FirstOrDefaultAsync(c=>c.Id.ToString()==id);
                

            if (course == null || course.UsersCourses.All(uc => uc.UserId != userId))
            {
                return null;
            }

            return mapper.Map<CourseRespondModel>(course);
        }
    }
}