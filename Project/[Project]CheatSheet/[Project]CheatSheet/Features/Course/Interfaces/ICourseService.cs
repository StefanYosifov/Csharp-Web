using _Project_CheatSheet.Features.Course.Models;

namespace _Project_CheatSheet.Features.Course.Interfaces
{
    public interface ICourseService
    {

       public Task<bool> JoinCourse();

       public Task<IEnumerable<CourseRespondModel>> GetAllCourses();
       public Task<CourseRespondModel> GetCourseDetails(string id);



    }
}
