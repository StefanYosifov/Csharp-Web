namespace Exercise.Controllers
{
    using Exercise.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json;

    public class ProductController : Controller
    {

        private IEnumerable<ProductModel> products = new List<ProductModel>()
        {
            new ProductModel()
            {
                Id=1,
                Name="Kartofi",
                Quantity=100
            },
            new ProductModel()
            {
                Id = 2,
                Name = "Krastavici",
                Quantity = 1000
            },
            new ProductModel()
            {
                Id = 3,
                Name = "Domati",
                Quantity = 10000
            },
         };

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword == null)
            {
                return View(products);
            }
            var foundProduct=this.products.Where(x => x.Name.Contains(keyword)).ToArray();
            return View(foundProduct);
        }

        public IActionResult ById(int id)
        {
            ProductModel product = products.FirstOrDefault(p => p.Id==id);
            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }

        public IActionResult AllJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            return Json(products,options);
        }

        public IActionResult AllText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.Append($"{product.Id}");
                sb.Append($" {product.Name}");
                sb.Append($" {product.Quantity}");
            }
            return Content(sb.ToString());
        }
    }
}
