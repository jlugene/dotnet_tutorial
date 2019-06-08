using MerchantSupport.Lib;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MerchantSupport.Tutorial
{
	//第19课：模型验证4 - 模型级错误的验证
	public class Lesson19Controller : Controller
	{
		public class HolidayVo :IValidatableObject
		{
			[DisplayName("日期")]
			[NotEmpty]
			[Date]
			public string Day { get; set; }

			[DisplayName("名称")]
			[NotEmpty]
			public string Name { get; set; }

			//模型级错误的验证方式。
			//只有不存在属性级错误的时候会调用；如果有属性级错误不会调用
			public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
			{
				var holiday = DateAttribute.FromDateString(this.Day).Value;
				if(T_Holiday.Count(Where.Eq(nameof(T_Holiday.Holiday), holiday)) > 0)
				{
					yield return new ValidationResult("该日期已存在。不可加入重复的假期。", new string[] { nameof(Day) });
				}
			}
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