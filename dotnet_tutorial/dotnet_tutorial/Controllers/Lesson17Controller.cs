using MerchantSupport.Lib;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MerchantSupport.Tutorial
{
	public class Lesson17Controller : Controller
	{
		public class Holiday
		{
			[DisplayName("日期")]
			[NotEmpty]
			[Date]
			public string Day { get; set; }

			[DisplayName("名称")]
			[NotEmpty]
			public string Name { get; set; }
		}

		public IActionResult Index()
		{
			return View(new Holiday());
		}

		[HttpPost]
		public IActionResult Show(Holiday holiday)
		{
			if(!ModelState.IsValid)
			{
				return View("Index", holiday);
			}
			return Content($"假日日期：{holiday.Day}; 假日名称：{holiday.Name}");
		}
	}
}