using Microsoft.AspNetCore.Mvc;
using System;

namespace MerchantSupport.Tutorial
{
	public class Lesson13Controller : Controller
	{
		public class Holiday
		{
			public string Day { get; set; }
			public string Name { get; set; }
		}

		public IActionResult Index()
		{
			return View(new Holiday());
		}

		[HttpPost]
		public IActionResult Show(Holiday holiday)
		{
			return Content($"假日日期：{holiday.Day}; 假日名称：{holiday.Name}");
		}
	}
}