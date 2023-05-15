using _Project_CheatSheet.Features.Course.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace _Project_CheatSheet.Features.Course
{
    [Authorize]
    public class CourseController:ApiController
    {

        private readonly ICourseService service;

        public CourseController(ICourseService service)
        {
            this.service = service;
        }
    }
}
