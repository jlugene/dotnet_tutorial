using Microsoft.AspNetCore.Mvc;

namespace MerchantSupport.Tutorial
{
	public class Lesson9Controller : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}