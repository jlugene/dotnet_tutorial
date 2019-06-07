using Microsoft.AspNetCore.Mvc;

namespace MerchantSupport.Tutorial
{
	public class Lesson11Controller : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public string Show(string holidayName, string holidayDate)
		{
			return $"假日日期：{holidayDate}; 假日名称：{holidayName}";
		}
	}
}