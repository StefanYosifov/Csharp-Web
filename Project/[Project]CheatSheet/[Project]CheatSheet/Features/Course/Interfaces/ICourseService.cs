namespace _Project_CheatSheet.Features.Course.Interfaces
{
    using Models;

    public interface ICourseService
    {
        public Task<bool> JoinCourse(string id);
        public Task<IEnumerable<CourseRespondAllModel>> GetAllCourses(int page);
        public Task<CourseRespondModel> GetCourseDetails(string id);

        public Task<CourseRespondPaymentModel> GetPaymentDetails(string id);
    }
}