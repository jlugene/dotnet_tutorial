using MerchantSupport.Lib;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MerchantSupport.Tutorial
{
	//第22课：修正数据
	public class Lesson23Controller : Lesson22Controller
	{
		[HttpGet]
		public IActionResult Edit(string id)
		{
			var record = T_Holiday.Find(id);
			var vo = new HolidayVo
			{
				Id = record.Id,
				Day = record.Holiday.ToJapanDate(),
				Name = record.Holiday_Name
			};
			return View(vo);
		}

		[HttpPost]
		public IActionResult Update(HolidayVo vo)
		{
			if (!ModelState.IsValid)
			{
				return View("Edit", vo);
			}
			var record = new T_Holiday
			{
				Id = vo.Id,
				Holiday = DateAttribute.FromDateString(vo.Day).Value,
				Holiday_Name = vo.Name
			};
			record.Update();
			return View(vo);
		}


		public class HolidayVo : IValidatableObject
		{
			[DisplayName("ID")]
			[NotEmpty]
			public int Id { get; set; }

			[DisplayName("日期")]
			[NotEmpty]
			[Date]
			public string Day { get; set; }

			[DisplayName("名称")]
			[NotEmpty]
			public string Name { get; set; }

			//模型级错误的验证方式。
			public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
			{
				//逻辑与新规时不太相同
				var holiday = DateAttribute.FromDateString(this.Day).Value;
				var count = T_Holiday.Count(Where.And(
					Where.Eq(nameof(T_Holiday.Holiday), holiday),
					Where.NotEq(nameof(T_Holiday.Id), this.Id)
				));
				if (count > 0)
				{
					yield return new ValidationResult("该日期已存在。不可加入重复的假期。", new string[] { nameof(Day) });
				}
			}
		}
	}
}