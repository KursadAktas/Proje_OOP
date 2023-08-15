using Microsoft.AspNetCore.Mvc;

namespace Proje_OOP.Controllers
{
    public class Default : Controller
    {
        void messages()
        {
            ViewBag.m1 = "Merhaba bu bir core projesi";
            ViewBag.m2 = "Merhaba proje çok iyi";
            ViewBag.m3 = "Selamlar";
        }
       
        public IActionResult Index()
        {
            messages();
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }
    }
}
