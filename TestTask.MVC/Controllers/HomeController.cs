using Microsoft.AspNetCore.Mvc;
using TestTask.MVC.Models;

namespace TestTask.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Info", "Home", person);
            }
            return View(person);
            
        }

        public IActionResult Info(Person person)
        {
            return View(person);
        }
    }
}
