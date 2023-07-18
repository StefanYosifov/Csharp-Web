namespace _Project_CheatSheet.Features.Course
{
    using Common.Filters;
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
        [ActionFilter("", CourseMessages.OnUnsuccessfulCourseRetrieval, StatusCodes.Status404NotFound)]
        public async Task<CourseRespondModel> GetCourse(string id) =>
            await service.GetCourseDetails(id);

        [HttpGet("payment/{id}")]
        [ActionFilter("", CourseMessages.OnUnsuccessfulCourseRetrieval)]
        public async Task<CourseRespondPaymentModel> GetCoursePaymentDetails(string id) =>
            await service.GetPaymentDetails(id.ToLower());

        [HttpGet("all/{page}")]
        [ActionFilter()]
        public async Task<IEnumerable<CourseRespondAllModel>> GetAllCourses(int page, [FromQuery] CourseRequestQueryModel query) =>
            await service.GetAllCourses(page, query);

        [HttpGet("my/{page}")]
        [ActionFilter()]
        public async Task<IEnumerable<CourseRespondAllModel>> GetMyCourses(int page, [FromQuery] string? toggle) =>
            await service.GetMyCourses(page, toggle);

        [HttpGet("languages")]
        [ActionFilter()]
        public async Task<ICollection<string>> GetLanguages() =>
            await service.GetCoursesLanguages();

        [HttpPost("payment/{id}")]
        [ActionFilter(CourseMessages.OnSuccessfulPayment, CourseMessages.OnSuccessfulPayment, StatusCodes.Status403Forbidden)]
        public async Task<bool> JoinCourse(string id) =>
            await service.JoinCourse(id);
    }
}