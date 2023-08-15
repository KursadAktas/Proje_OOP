using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Proje_OOP.Entity;
using Proje_OOP.ProjeContext;

namespace Proje_OOP.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Products.Where(x=> x.IsDeleted == false).ToList();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            context.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = context.Products.Where(x =>x.Id == id ).FirstOrDefault(); // bulunan satırı buluyor
           value.IsDeleted = true;
            context.Update(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult UpdateProduct(int id)
        {
            var value = context.Products.Where(x=>x.Id == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]

        public IActionResult UpdateProduct(Product p) // parametre olarak p verdim
        {
            var value = context.Products.Where(x=>x.Id==p.Id).FirstOrDefault();
            value.Name = p.Name; // value için yeni değer dışarıdan gönderilen p değeri
            value.Price = p.Price;
            value.Stock = p.Stock;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}