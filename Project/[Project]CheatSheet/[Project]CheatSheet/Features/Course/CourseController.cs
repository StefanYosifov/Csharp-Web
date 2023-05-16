using _Project_CheatSheet.Features.Course.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace _Project_CheatSheet.Features.Course
{
    [Authorize]
    [Route("/course")]
    public class CourseController:ApiController
    {

        private readonly ICourseService service;

        public CourseController(ICourseService service)
        {
            this.service = service;
        }
    }
}
