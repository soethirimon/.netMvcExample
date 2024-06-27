using MVCExample.Web.Features.Blog;

namespace MVCExample.Web.Features.Student
{
    public interface IStudentService
    {
       
        Task<int> CreateStudent(StudentDataModel model);
        Task<List<StudentDataModel>> GetStudentList();
        Task<int> DeleteStudent(int id);
        Task<StudentDataModel> GetById(int id);

        Task<int> UpdateStudent(int id,StudentDataModel model);

    }
}
