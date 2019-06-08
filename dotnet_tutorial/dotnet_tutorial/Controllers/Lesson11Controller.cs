using Microsoft.AspNetCore.Mvc;

namespace MerchantSupport.Tutorial
{
	public class Lesson11Controller : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public string Show(string day, string name)
		{
			return $"假日日期：{day}; 假日名称：{name}";
		}
	}
}