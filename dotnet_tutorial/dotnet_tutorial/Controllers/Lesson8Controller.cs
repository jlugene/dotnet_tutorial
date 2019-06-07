using Microsoft.AspNetCore.Mvc;

namespace MerchantSupport.Tutorial
{
	public class Lesson8Controller : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}