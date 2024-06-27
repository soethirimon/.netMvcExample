using Microsoft.EntityFrameworkCore;
using MVCExample.Web.EFDbContext;
using MVCExample.Web.Features.Blog;

namespace MVCExample.Web.Features.Student
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateStudent(StudentDataModel model)
        {
            int result = 0;
            try
            {
                model.CreatedDate = DateTime.Now;
                await _context.Student.AddAsync(model);
                

                result = await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e); 
                throw;
            }

            return result;
        }

        public async Task<List<StudentDataModel>> GetStudentList()
        {
            var studentList = await _context
                .Student
                .AsNoTracking()
                .Where(x => !x.IsDelete)
                .ToListAsync();

            return studentList;
        }

        public async Task<int> DeleteStudent(int id)
        {
            int result = 0;
            try
            {
                var student = await _context.Student
                    .FirstOrDefaultAsync(x => !x.IsDelete && x.StudentId == id);
                if (student == null) return -1;

                student.IsDelete = true;
                student.ModifiedDate = DateTime.Now;
                _context.Entry(student).State = EntityState.Modified;

                result = await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        public async Task<StudentDataModel> GetById(int id)
        {
            var model = await _context
                .Student
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.IsDelete == false && x.StudentId == id);

            return model;
        }


        public async Task<int> UpdateStudent(int id, StudentDataModel model)
        {
            int result = 0;

            try
            {
                var student = await _context
                    .Student
                    .FirstOrDefaultAsync(x =>
                        x.IsDelete == false &&
                        x.StudentId == id);

                if (student == null) return -1;

                student.StudentName = model.StudentName;
                student.StudentAddress = model.StudentAddress;
                student.StudentDescription = model.StudentDescription;
                student.ModifiedDate = DateTime.Now; // Need Modified User

                _context.Student.Update(student);
                result = await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }








    }
}
