using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyNet7.Models;

namespace VidlyNet7.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        [Route("Customers/Details/{paramId}")]
        public IActionResult Details(int paramId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == paramId);

            if (customer != null)
                return View(customer);
            else return NotFound();




        }
    }
}

