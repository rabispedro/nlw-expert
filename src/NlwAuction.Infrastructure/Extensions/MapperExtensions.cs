using Microsoft.Extensions.DependencyInjection;

namespace NlwAuction.Infrastructure.Extensions;

public static class MapperExtensions
{
	public static IServiceCollection AddMappers(this IServiceCollection service)
	{
		// service.AddAutoMapper();

		return service;
	}
}
