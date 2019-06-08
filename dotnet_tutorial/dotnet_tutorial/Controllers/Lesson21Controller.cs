using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MerchantSupport.Lib;

namespace MerchantSupport.Tutorial
{
	//第21课：数据库查询2 - 分页显示列表
	//需要引入MerchantSupport.Lib.Pagination库
	public class Lesson21Controller : Controller
	{
		public IActionResult Index()
		{
			PagingConfig.NumPerPage = 10;
			var quering = new HolidayQuering();
			var model = this.CreatePagingModel(quering);
			return View(model);
		}

		//MerchantSupport.Lib.Pagination框架中，
		//BaseQueringCondition是实现检索功能 + csv下载 + 分页查询的检索类基类
		//HolidayQuering继承自它，实现查询
		public class HolidayQuering : BaseQueringCondition
		{
			public override IRecords QueryAll()
			{
				throw new System.NotImplementedException();
			}

			protected override int QueryRecordsCount()
			{
				return T_Holiday.Count();
			}

			public override IRecords QueryPage(int pageNo, int numPerPage)
			{
				//FindPage:第一个参数是页号，从1开始计数；第二个参数是每页记录的个数
				var records = T_Holiday.FindPage(pageNo, numPerPage);
				return new WrappedRecords<T_Holiday>(records);
			}
		}
	}
}