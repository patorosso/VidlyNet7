using Microsoft.AspNetCore.Mvc;
using VidlyNet7.Models;

namespace VidlyNet7.Controllers
{
    public class CustomersController : Controller
    {
        public IEnumerable<Customer> CustomersList()
        {
            return new List<Customer>
            {
                new Customer { Id= 1, Name = "John Smith" },
                new Customer { Id= 2, Name = "Mary Williams" }
            };
        }
        public IActionResult Index()
        {
            return View(CustomersList());
        }

        [Route("Customers/Details/{paramId}")]
        public IActionResult Details(int paramId)
        {
            var customer = CustomersList().FirstOrDefault(c => c.Id == paramId);

            if (customer != null)
                return View(customer);
            else return NotFound();




        }
    }
}

