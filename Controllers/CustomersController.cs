using Microsoft.AspNetCore.Mvc;
using VidlyNet7.Models;

namespace VidlyNet7.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            List<Customer> customers = new()
            {
                new Customer { Name = "John Smith" },
                new Customer { Name = "Mary Williams" }
            };

            return View(customers);
        }

        public IActionResult Details()
        {


            return View();
        }
    }
}

