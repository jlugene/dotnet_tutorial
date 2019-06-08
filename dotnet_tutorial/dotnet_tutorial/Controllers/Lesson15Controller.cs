using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace MerchantSupport.Tutorial
{
	public class Lesson15Controller : Controller
	{
		public class Holiday
		{
			[Required]
			public string Day { get; set; }

			[Required]
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