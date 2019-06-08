using Microsoft.AspNetCore.Mvc;

namespace MerchantSupport.Tutorial
{
	//第24课：删除数据
	public class Lesson24Controller : Lesson23Controller
	{
		[HttpPost]
		public IActionResult Delete(string id)
		{
			T_Holiday.DeleteById(id);
			var referer = this.Request.Headers["Referer"].ToString();
			return Redirect(referer);
		}
	}
}