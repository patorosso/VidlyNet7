using Microsoft.AspNetCore.Mvc;
using mox_mvc_crud.Models;

namespace mox_mvc_crud.Controllers
{
	public class MoviesController : Controller
	{
		// GET: Movies/Random
		public IActionResult Random()
		{
			var movie = new Movie() { Name = "Inception" };

			return View(movie);
		}
		public ActionResult Edit(int id) => Content("id=" + id);
		//movies
		public ActionResult Index(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue)
				pageIndex = 1;

			if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

			return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
		}
	}
}
