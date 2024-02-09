using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using NlwAuction.Infrastructure.DataAccess.Contexts;

namespace NlwAuction.Infrastructure.Extensions;

public static class HealthChecksExtensions
{
	public static IServiceCollection AddHealthChecks(this IServiceCollection services)
	{
		var healthChecks = services.AddHealthChecks();

		var featureManager = services.BuildServiceProvider().GetRequiredService<IFeatureManager>();

		bool isEnabled = featureManager
			.IsEnabledAsync(nameof(AuctionDbContext))
			.ConfigureAwait(false)
			.GetAwaiter()
			.GetResult();

		if (isEnabled)
			healthChecks.AddDbContext<AuctionDbContext>();

		return services;
	}
}
