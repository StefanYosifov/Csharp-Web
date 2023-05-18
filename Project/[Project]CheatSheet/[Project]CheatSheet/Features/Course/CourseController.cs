using _Project_CheatSheet.Features.Course.Interfaces;
using _Project_CheatSheet.GlobalConstants.Resource;
using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(string id)
        {
            var courseResult = await service.GetCourseDetails(id);
            if (courseResult == null)
            {
                return NotFound(CourseMessages.OnUnsuccessfulCourseRetrieval);
            }

            return Ok(courseResult);
        }

        [HttpGet("all/{page}")]
        public async Task<IActionResult> GetAllCourses(int page)
        {
            var coursesResult=await service.GetAllCourses(page);
            return Ok(coursesResult);
        }

        [HttpPost("payment/{id}")]
        public async Task<IActionResult> JoinCourse(string id)
        {
            var courseResult = await service.JoinCourse(id);
            if (!courseResult)
            {
                return Forbid(CourseMessages.OnSuccessfulPayment);
            }

            return Ok(CourseMessages.OnSuccessfulPayment);
        }
    }
}
