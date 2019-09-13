using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DocumentIO.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateWebHostBuilder(string[] args) =>
			new HostBuilder()
				.ConfigureLogging(builder => builder.AddConsole())
				.ConfigureAppConfiguration(builder =>
					builder.AddJsonFile("appsettings.json", optional: true)
						.AddEnvironmentVariables("DocumentIO:"))
				.ConfigureWebHost(builder => builder
					.UseKestrel()
					.UseStartup<Startup>());
	}
}