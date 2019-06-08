using MerchantSupport.Lib;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MerchantSupport.Tutorial
{
	public class Lesson18Controller : Controller
	{
		public class HolidayVo
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
			return View(new HolidayVo());
		}

		[HttpPost]
		public IActionResult Create(HolidayVo vo)
		{
			if (!ModelState.IsValid)
			{
				return View("Index", vo);
			}
			var record = new T_Holiday
			{
				Holiday = DateAttribute.FromDateString(vo.Day).Value,
				Holiday_Name = vo.Name
			};
			record.Insert();
			return View(record);
		}
	}
}