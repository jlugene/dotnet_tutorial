using MerchantSupport.Lib;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;

namespace MerchantSupport.Tutorial
{
	//第22课：数据库查询3 - csv下载
	//需引入Lib.Mvc.Extension库
	public class Lesson22Controller : Controller
	{
		public IActionResult Index()
		{
			PagingConfig.NumPerPage = 10;
			var quering = new HolidayQuering();
			var model = this.CreatePagingModel(quering);
			return View(model);
		}

		public IActionResult Download()
		{
			var quering = new HolidayQuering();
			//CsvActionResult是Lib.Mvc.Extension库提供的HTTP csv响应结果
			return new CsvActionResult(quering.QueryAll(), true, encoding: Encoding.UTF8);
		}

		//实现T_Holiday的查询
		public class HolidayQuering : BaseQueringCondition
		{
			//QueryAll做全表查询，常用于csv下载
			public override IRecords QueryAll()
			{
				var records = T_Holiday.FindAll();
				return new HolidayCsvList(records);
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

		//WrappedRecords是MVC中数据记录集合的基类
		//HolidayCsvList定义csv文件中，各个标题、各个列的取值。
		public class HolidayCsvList : WrappedRecords<T_Holiday>
		{
			public HolidayCsvList(IEnumerable<T_Holiday> rawRecords) : base(rawRecords) { }

			public override IEnumerable<string> GetHeaders()
			{
				return new string[] {
					"ID",
					"日期",
					"列表"
				};
			}

			public override IEnumerable<string> GetFields(T_Holiday record)
			{
				return new string[]
				{
					record.Id.ToString(),
					record.Holiday.ToJapanDate(),
					record.Holiday_Name,
				};
			}
		}
	}
}