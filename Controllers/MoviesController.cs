using Microsoft.AspNetCore.Mvc;
using VidlyNet7.Models;
using VidlyNet7.ViewModels;

namespace VidlyNet7.Controllers
{
	public class MoviesController : Controller
	{
		// GET: Movies/Random
		public IActionResult Random()
		{
			var movie = new Movie() { Name = "Inception" };
			var customers = new List<Customer>
			{
				new Customer { Name = "Customer 1"},
				new Customer { Name = "Customer 2"}

		};
			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};

			return View(viewModel);
		}
		public IActionResult Edit(int id) => Content("id=" + id);
		//movies
		public IActionResult Index(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue)
				pageIndex = 1;

			if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

			return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
		}
	}
}
