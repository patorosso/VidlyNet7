using Microsoft.AspNetCore.Mvc;

namespace VidlyNet7.Controllers
{
	public class CustomersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

