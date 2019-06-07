using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;

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
				.OrderBy(t => GetLessonNo(t))
				.ToArray();
			return View(items);
		}

		private int GetLessonNo(string name)
		{
			var match = Regex.Match(name, @"\d+");
			return match.Success ? int.Parse(match.Value) : 0;
		}
	}
}