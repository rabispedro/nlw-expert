using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NlwAuction.Domain.Interfaces.DataAccess.Repositories;
using NlwAuction.Infrastructure.DataAccess.Contexts;
using NlwAuction.Infrastructure.DataAccess.Repositories;

namespace NlwAuction.Infrastructure.Extensions;

public static class DataAccessExtensions
{
	public static IServiceCollection AddDataAccess(this IServiceCollection service, IConfiguration configuration)
	{
		service.AddDbContext<NlwAuctionDbContext>(options =>
		{
			options.UseNpgsql(configuration.GetConnectionString("PersistanceDataConnection")!);
		});

		service.AddScoped<IAuctionRepository, AuctionRepository>();
		service.AddScoped<IOfferRepository, IOfferRepository>();
		service.AddScoped<IUserRepository, UserRepository>();

		return service;
	}
}
