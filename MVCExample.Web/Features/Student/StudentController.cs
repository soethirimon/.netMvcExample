
using Microsoft.AspNetCore.Mvc;
using MVCExample.Web.Features.Base;
using MVCExample.Web.Features.Student;
using System;
using System.Threading.Tasks;

namespace MVCExample.Web.Features.Student
{
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {

            return View();
        }


        //Create Student
        [HttpGet]
        public IActionResult CreateStudent()
        {
            var model = new StudentRequestModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveStudent(StudentRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var studentDataModel = new StudentDataModel
                {
                    StudentName = model.StudentName,
                    StudentAddress = model.StudentAddress,
                    StudentDescription = model.StudentDescription,
                    
                };

                try
                {
                    int result = await _studentService.CreateStudent(studentDataModel);
                   
                    TempData["Message"] = "Student created successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    
                    ModelState.AddModelError("", "Failed to save student. Please try again.");
                    Console.WriteLine(ex); 
                }
            }

         
            return View("CreateStudent", model);
        }

        //Student List
        [HttpGet]
        public async Task<IActionResult> GetStudentList()
        {
        
            var students = await _studentService.GetStudentList();
            return Ok(students);
        }



        //Delete Student
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            string message = string.Empty;
            try
            {
                bool isInt = int.TryParse(id, out int studentId);
                if (!isInt)
                {
                    TempData["Message"] = "404 Not Found.";
                    return RedirectToAction(nameof(Index));
                }

                int result = await _studentService.DeleteStudent(studentId);
                message = result > 0
                    ? "Student is deleted successfully!"
                    : "Student deletion error!";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                message = "Something went wrong! Please try again later.";
            }

            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));
        }

        //Update Student
        public async Task<IActionResult> EditStudent(string id)
        {
            StudentRequestModel model = new StudentRequestModel();

            try
            {
                bool isInt = int.TryParse(id, out int studentId);

                if (!isInt)
                {
                    TempData["Message"] = "404 Not Found.";
                    return RedirectToAction(nameof(Index));
                }

                var data = await _studentService.GetById(studentId);
                if (data == null)
                {
                    TempData["Message"] = "404 Not Found.";
                    return RedirectToAction(nameof(Index));
                }

                model.StudentId = data.StudentId;
                model.StudentName = data.StudentName;
                model.StudentAddress = data.StudentAddress;
                model.StudentDescription = data.StudentDescription;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["Message"] = "Something went wrong! Please try again later.";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> UpdateStudent(StudentRequestModel model)
        {
            string message = string.Empty;
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nameof(EditStudent), model);
                }

                var data = new StudentDataModel
                {
                    StudentId = model.StudentId,
                    StudentName = model.StudentName,
                    StudentAddress = model.StudentAddress,
                    StudentDescription = model.StudentDescription,
                    ModifiedDate = DateTime.Now // Need Modified User
                };

                int result = await _studentService.UpdateStudent(model.StudentId, data);
                message = result > 0
                    ? "Student data is updated successfully!"
                    : "Update Error";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                message = "Something went wrong! Please try again later.";
            }

            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));
        }



    }
}
