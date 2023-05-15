using _Project_CheatSheet.Common.CurrentUser.Interfaces;
using _Project_CheatSheet.Data;
using _Project_CheatSheet.Features.Course.Interfaces;
using _Project_CheatSheet.Features.Course.Models;
using _Project_CheatSheet.Infrastructure.Data;
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


        public Task<bool> JoinCourse()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CourseRespondModel>> GetAllCourses()
        {
            return await context.Courses.ProjectTo<CourseRespondModel>(mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<CourseRespondModel> GetCourseDetails(string id)
        {
            var userId = currentUserService.GetUserId();
            var course = await context.Courses.FirstOrDefaultAsync(c => c.Id.ToString() == id);
            if (course == null || course.UsersCourses.All(uc => uc.UserId != userId))
            {
                return null;
            }

            return mapper.Map<CourseRespondModel>(course);
        }
    }
}