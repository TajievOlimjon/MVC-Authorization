using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAvtorize.Areas.Admin.Models.ModelDTO;
using WebAvtorize.Services;

namespace WebAvtorize.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StudentController : Controller
    {
        private readonly StudentService studentService;
        private readonly CourseService courseService;

        public StudentController(StudentService _studentService,CourseService _courseService)
        {
            studentService = _studentService;
            courseService = _courseService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await studentService.GetStudents();
            return View(list);
        }
       
        [HttpGet]        
        public async  Task<IActionResult> Create()
        {
            var courses = await courseService.GetCourses();
            ViewBag.Courses = courses;
            return View(new StudentDTO());
        }

        [HttpPost] 
        public async Task<IActionResult> Create(StudentDTO student)
        {
            var courses =await courseService.GetCourses();
            ViewBag.Courses = courses;
            if (ModelState.IsValid)
            {
                await studentService.Added(student);
                return RedirectToAction(nameof(Index));

            }
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var courses = await courseService.GetCourses();
            ViewBag.Courses = courses;
            var student = await studentService.GetStudentById(Id);
            return View(student);
        }

        [HttpPost]
        public  async Task<IActionResult> Edit(StudentDTO student)
        {
            var courses = await courseService.GetCourses();
            ViewBag.Courses = courses;
            if (!ModelState.IsValid) return  View(student);
            await studentService.Edit(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var courses = await courseService.GetCourses();
            ViewBag.Courses = courses;
            var student =await studentService.GetStudentById(Id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(StudentDTO student)
        {
            var courses = await courseService.GetCourses();
            ViewBag.Courses = courses;
            await studentService.Delete(student);
            return RedirectToAction("Index");
        }
    }
}
