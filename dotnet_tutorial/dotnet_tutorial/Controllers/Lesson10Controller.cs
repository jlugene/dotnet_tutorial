using Microsoft.AspNetCore.Mvc;

namespace MerchantSupport.Tutorial
{
	public class Lesson10Controller : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}