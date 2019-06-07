using Microsoft.AspNetCore.Mvc;
using System;

namespace MerchantSupport.Tutorial
{
	public class Lesson4Controller : Controller
	{
		public class Holiday
		{
			public DateTime Day { get; set; }
			public string Name { get; set; }
		}

		public IActionResult Index()
		{
			var model = new Holiday[]
			{
				new Holiday
				{
					Day = new DateTime(2019,1,1),
					Name = "元旦"
				},
				new Holiday
				{
					Day = new DateTime(2019,10,1),
					Name = "国庆"
				},
				new Holiday
				{
					Day = new DateTime(2019, 12, 25),
					Name = "圣诞"
				}
			};
			return View(model);
		}
	}

}