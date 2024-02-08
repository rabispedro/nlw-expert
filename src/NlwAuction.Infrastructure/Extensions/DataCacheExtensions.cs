using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NlwAuction.Infrastructure.Extensions;

public static class DataCacheExtensions
{
	public static IServiceCollection AddCache(IServiceCollection service, IConfiguration configuration)
	{

		return service;
	}
}
