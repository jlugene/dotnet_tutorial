using Microsoft.AspNetCore.Mvc;

namespace MerchantSupport.Tutorial
{
	public class Lesson7Controller : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Show()
		{
			return Redirect("/lesson2");
		}
	}
}