﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MerchantSupport.Lib;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MerchantSupport.Tutorial
{
	public class Program
	{
		public static void Main(string[] args)
		{
			DB.AddSchema("dotnet_tutorial", new MysqlSetting
			{
				DataSource = "localhost",
				Database = "dotnet_tutorial",
				UserId = "root",
				Password = "123456"
			});
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			 WebHost.CreateDefaultBuilder(args)
				  .UseStartup<Startup>();
	}
}
