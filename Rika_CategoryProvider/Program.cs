using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rika_CategoryProvider.Infrastructure.Context;



var host = new HostBuilder()
	.ConfigureFunctionsWebApplication()
	.ConfigureServices((context, services) =>
	{
		services.AddApplicationInsightsTelemetryWorkerService();
		services.ConfigureFunctionsApplicationInsights();

		services.AddDbContext<CategoryDbContext>(options => options.UseSqlServer(context.Configuration.GetConnectionString("OrderProviderDb")));
	

	})
	.Build();



host.Run();