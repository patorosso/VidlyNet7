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
                new Customer { Id= 1, Name = "John Smith" },
                new Customer { Id= 2, Name = "Mary Williams" }
            };

            return View(customers);
        }

        [Route("Customers/Details/{paramId}")]
        public IActionResult Details(int paramId)
        {
            List<Customer> customers = new()
            {
                new Customer { Id= 1, Name = "John Smith" },
                new Customer { Id= 2, Name = "Mary Williams" }
            };

            var customer = customers.FirstOrDefault(c => c.Id == paramId);

            if (customer != null)
                return View(customer);
            else return NotFound();




        }
    }
}

