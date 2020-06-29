using System.Web.Mvc;
using TestApp_MVC.Models;
using TestApp_MVC.Repository;
using TestApp_MVC.ViewModels;

namespace TestApp_MVC.Controllers
{
    public class HomeController : Controller
    {
        public readonly IStudentRepository _studentRepository;
        public HomeController()
        {
            _studentRepository = new StudentRepository();
        }

        public ActionResult Index()
        {
            var model = new StudentModuleViewModel
            {
                Students = _studentRepository.Get(),
                NthHighestPoketModeyStudent = _studentRepository.GetNthHighestPocketMoneyStudent(2)
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult SaveStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Save(student);
            }
            return RedirectToAction("Index");
        }
    }
}