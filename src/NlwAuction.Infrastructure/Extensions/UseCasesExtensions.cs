using Microsoft.Extensions.DependencyInjection;
using NlwAuction.Application.UseCases.Auctions.GetCurrent;
using NlwAuction.Application.UseCases.Interfaces.Auctions.GetCurrent;

namespace NlwAuction.Infrastructure.Extensions;

public static class UseCasesExtensions
{
	public static IServiceCollection AddUseCases(this IServiceCollection services)
	{
		services.AddScoped<IGetCurrentAuctionUseCase, GetCurrentAuctionUseCase>();

		return services;
	}
}
