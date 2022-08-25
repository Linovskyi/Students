using Microsoft.AspNetCore.Mvc;
using Student.Infrastructure.Persistent;
using Students.Models;

namespace Students.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var students = await studentRepository.GetAll();
            var result = new List<StudentVievModel>();
            foreach (var student in students)
            {
                result.Add(new StudentVievModel
                {
                    Id = student.Id,
                    FirsName = student.FirstName,
                    LastName = student.LastName,
                    Birthday = student.Birthday,
                    RecordBook = student.RecordBook,

                });
            }
            return View(new StudentsVievModel
            {
                Students = result
            });

        }

        public async Task<IActionResult> Details(int id = 0)
        {
            if (id == 0)
            {
                return this.View(new StudentVievModel());
            }
            var student = await studentRepository.FindById(id);
            if (student == null)
            {
                this.RedirectToAction("Error", "Home");
            }
            return this.View(new StudentVievModel
            {
                Id = student.Id,
                FirsName = student.FirstName,
                LastName = student.LastName,
                Birthday = student.Birthday,
                RecordBook = student.RecordBook,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentVievModel model)
        {
            var student = await this.studentRepository.FindById(model.Id);
            if (student == null)
            {
                var newStudent = await this.studentRepository.Create(
                    model.FirsName, 
                    model.LastName, 
                    model.Birthday, 
                    model.RecordBook);
                return this.RedirectToAction("Details","Students", new { id = model.Id});
            }
            await this.studentRepository.Update(
                    model.Id,
                    model.FirsName,
                    model.LastName,
                    model.Birthday,
                    model.RecordBook);
            return this.RedirectToAction("Details", "Students", new { id = model.Id });
        }
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await this.studentRepository.Delete(id);
            return this.RedirectToAction("index");
        }
    }
}
