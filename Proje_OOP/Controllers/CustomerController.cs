using Microsoft.AspNetCore.Mvc;
using Proje_OOP.Entity;
using Proje_OOP.ProjeContext;
using System.Security.Cryptography.X509Certificates;

namespace Proje_OOP.Controllers
{
    public class CustomerController : Controller
    {
        Context _context = new Context(); //bir database oluştur
        public IActionResult Index()
        {
            var values = _context.Customers.Where(x=> x.IsDeleted == false).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            if (p.CustomerName.Length>= 10 && p.CustomerCity! =="" && p.CustomerCity.Length >= 3)
            {
                _context.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Hatalı Kullanım";
                return View();
            }
            
        }
        public IActionResult Delete(int id)
        {
            var value = _context.Customers.Where(x=>x.CustomerId==id).FirstOrDefault();
            value.IsDeleted = true;
            _context.Update(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Customers.Where(x=>x.CustomerId == id).FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Customer p)
        {
            var value = _context.Customers.Where(x=> x.CustomerId == p.CustomerId).FirstOrDefault();
            value.CustomerCity= p.CustomerCity;
            value.CustomerName= p.CustomerName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
