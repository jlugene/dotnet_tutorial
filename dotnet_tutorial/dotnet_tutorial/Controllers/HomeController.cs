using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Linq;

namespace MerchantSupport.Tutorial
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			var items = Assembly.GetEntryAssembly()
				.GetTypes()
				.Where(t => typeof(Controller).IsAssignableFrom(t))
				.Where(t => t != typeof(HomeController))
				.Select(t => t.Name.Replace("Controller", ""))
				.ToArray();
			return View(items);
		}
	}
}