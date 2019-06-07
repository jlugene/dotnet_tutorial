using Microsoft.AspNetCore.Mvc;

namespace MerchantSupport.Tutorial
{
	public class Lesson2Controller : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}