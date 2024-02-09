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
		Console.WriteLine($"String de Conexão: {configuration.GetConnectionString("PersistanceDataConnection")}");
		
		service.AddDbContext<AuctionDbContext>(options =>
		{
			options.UseNpgsql(configuration.GetConnectionString("PersistanceDataConnection"));
		});

		service.AddScoped<IAuctionRepository, AuctionRepository>();

		return service;
	}
}
