using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NlwAuction.Infrastructure.DataAccess.Contexts;
using NlwAuction.Infrastructure.DataAccess.Repositories.Auctions;
using NlwAuction.Infrastructure.DataAccess.Repositories.Interfaces.Auctions;

namespace NlwAuction.Infrastructure.Extensions;

public static class DataAccessExtensions
{
	public static IServiceCollection AddDataAccess(this IServiceCollection service, IConfiguration configuration)
	{
		// service.AddDbContext<AuctionContext>(options =>
		// {
		// 	options.UseNpgsql(configuration["ConnectionStrings:PersistanceDataConnection"]);
		// });

		// service.AddScoped<IAuctionRepository, AuctionRepository>();

		return service;
	}
}
