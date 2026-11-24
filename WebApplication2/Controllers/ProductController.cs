using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("test")]
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult GetById([FromRoute(Name = "id")]int id,[FromQuery(Name = "id2")]int otherid)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Search(ProductFilter filter)
        {
            return View();
        }

        [HttpGet("json")]
        public IActionResult JsonAction()
        {
            return Json("Hello From Action");
        }
        [HttpGet("ProductCode/{code:int}")]
        public IActionResult GetProductByCode(int code)
        {
            return Json(new Product() { Id = code, Name = "Laptop" });
        }











        [HttpGet]
        public JsonResult Get()
        {
            var product = new List<Product>()
            {
                new Product { Id = 1, Name = "Laptop" },
                new Product {Id = 2, Name="TV"}
            };
            return Json(product);
        }
        public ActionResult GetProductById(int Id)
        {
            if (Id < 0)
                return BadRequest();
            else if (Id == 0)
                return RedirectToAction(nameof(Index));
            else if(Id < 10)
                return NotFound();
            else
                return Json(new Product() { Id = Id, Name = "Laptop" });

        }
        public IActionResult FileAction()
        {
            var fileBytes = System.IO.File.ReadAllBytes("");
            return File(fileBytes, "application/pdf");
        }
    }
}
