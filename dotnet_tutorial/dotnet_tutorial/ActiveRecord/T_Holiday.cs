using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using MerchantSupport.Lib;

namespace MerchantSupport.Tutorial
{
	[DbSchema("dotnet_tutorial")]
	[Table("t_holiday")]
	public class T_Holiday : ActiveRecord<T_Holiday>
	{
		[Column(IsPrimaryKey = true, AutoIncrement = true, NotNull = true)]
		public int Id { get; set; }

		/// <summary>
		/// 假日日期
		/// </summary>
		[Column(NotNull = true)]
		public DateTime Holiday { get; set; }

		/// <summary>
		/// 假日名称
		/// </summary>
		[Column]
		public string Holiday_Name { get; set; }
	}
}
