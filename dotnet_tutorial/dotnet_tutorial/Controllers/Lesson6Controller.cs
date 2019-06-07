using Microsoft.AspNetCore.Mvc;
using System;

namespace MerchantSupport.Tutorial
{
	public class Lesson6Controller : Controller
	{
		public IActionResult Index()
		{
			return View();
		}


		public IActionResult Show()
		{
			return View();
		}

		public IActionResult List()
		{
			return View();
		}
	}

}