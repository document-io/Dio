using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DocumentIO.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration(builder => builder.AddEnvironmentVariables("DocumentIO.Data:"))
				.ConfigureWebHostDefaults(webBuilder =>
					webBuilder.UseStartup<Startup>()
						.UseKestrel(options => options.AllowSynchronousIO = true));
	}
}