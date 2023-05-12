using Microsoft.AspNetCore.Mvc;
using MiniApp.Models;
using MiniApp.Repos;

namespace MiniApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepo _repo;

        public StudentsController(IStudentRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var all = await _repo.GetAllStudent();
            return View(all);
        }


        public IActionResult Add()
        {
            ViewBag.Message = "Add Student";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student model)
        {
            await _repo.Add(model);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(int Id)
        {
             var student = await _repo.GetStudentById(Id);
            if(student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> View(StudentDTO model)
        {
            var student = await _repo.Update(model);
            if(student == true)
            {
                // When Success
                return RedirectToAction("Index");
            }
            // When Errorr
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
           var student = await _repo.Delete(id);
            if(student == true)
            {
                // When Success
                return RedirectToAction("Index");
            }
            // When Error
            return RedirectToAction("Index");
        }
    }
}
