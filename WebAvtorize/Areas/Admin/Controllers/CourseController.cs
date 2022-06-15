using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAvtorize.Areas.Admin.Models.ModelDTO;
using WebAvtorize.Services;

namespace WebAvtorize.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CourseController : Controller
    {
        private readonly CourseService courseService;

        public CourseController(CourseService courseService)
        {
            this.courseService = courseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var list =await courseService.GetCourses();
            return View(list);
        }

       
        public async Task<IActionResult> Create()
        {
            return View(new CourseDTO());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CourseDTO course )
        {
            if (ModelState.IsValid)
            {
                await courseService.Add(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            var course =await courseService.GetCourseByid(id);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseDTO course)
        {
            if (ModelState.IsValid == false) return View(course);

            await courseService.Edit(course);
            return RedirectToAction("Index");

        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var course = await courseService.GetCourseByid(id);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CourseDTO course)
        {
            if (ModelState.IsValid == false) return View(course);

            await courseService.Delete(course);
            return RedirectToAction("Index");

        }

    }
}
