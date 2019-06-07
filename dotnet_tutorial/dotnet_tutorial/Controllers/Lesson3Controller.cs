using Microsoft.AspNetCore.Mvc;

namespace MerchantSupport.Tutorial
{
	public class Lesson3Controller : Controller
	{
		public IActionResult Index()
		{
			object model = "Hello, Model!";
			return View(model);
		}
	}
}