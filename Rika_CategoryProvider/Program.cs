using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rika_CategoryProvider.Infrastructure.Context;
using Rika_CategoryProvider.Infrastructure.Repos;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
	.ConfigureFunctionsWebApplication()
	.ConfigureServices((context, services) =>
	{
		services.AddApplicationInsightsTelemetryWorkerService();
		services.ConfigureFunctionsApplicationInsights();

		var connectionString = context.Configuration.GetConnectionString("CategoryProviderDb");
		if (string.IsNullOrEmpty(connectionString))
		{
			throw new InvalidOperationException("Connection string 'CategoryProviderDb' is not found.");
		}

		services.AddPooledDbContextFactory<CategoryDbContext>(options =>
		{
			options.UseSqlServer(connectionString);
		});

		services.AddScoped<CategoryRepository>();
		services.AddScoped<CategoryService>();

		services.AddLogging();
	})
	.Build();

host.Run();
