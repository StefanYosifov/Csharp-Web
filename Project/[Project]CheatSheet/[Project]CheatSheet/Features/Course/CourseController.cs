namespace _Project_CheatSheet.Features.Course
{
    using Infrastructure.Data.GlobalConstants.Course;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    [Route("/course")]
    public class CourseController : ApiController
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


        [HttpGet("payment/{id}")]
        public async Task<IActionResult> GetCoursePaymentDetails(string id)
        {
            var courseResult = await service.GetPaymentDetails(id.ToLower());
            if (courseResult == null)
            {
                return BadRequest(CourseMessages.OnUnsuccessfulCourseRetrieval);
            }

            return Ok(courseResult);
        }

        [HttpGet("all/{page}")]
        public async Task<IActionResult> GetAllCourses(int page, [FromQuery]CourseRequestQueryModel query)
        {
            var coursesResult = await service.GetAllCourses(page,query);
            return Ok(coursesResult);
        }

        [HttpGet("my/{page}")]
        public async Task<IActionResult> GetMyCourses(int page)
        {
            var coursesResult = await service.GetMyCourses(page);
            return Ok(coursesResult);
        }

        [HttpGet("languages")]
        public async Task<IActionResult> GetLanguages()
        {
            var languagesResult = await service.GetCoursesLanguages();
            return Ok(languagesResult);
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