using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MerchantSupport.Tutorial
{
	//第20课：数据库查询 - 单页显示列表
	public class Lesson20Controller : Controller
	{
		public IActionResult Index()
		{
			var model = T_Holiday.FindAll().ToArray();
			return View(model);
		}
	}
}