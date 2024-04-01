using Microsoft.EntityFrameworkCore;
using NlwAuction.Domain.Entities;
using NlwAuction.Domain.Interfaces.DataAccess.Repositories;
using NlwAuction.Infrastructure.DataAccess.Contexts;

namespace NlwAuction.Infrastructure.DataAccess.Repositories;

public class AuctionRepository : IAuctionRepository
{
	private readonly NlwAuctionDbContext _dbContext;
	public AuctionRepository(NlwAuctionDbContext dbContext)
	{
		ArgumentNullException.ThrowIfNull(dbContext);

		_dbContext = dbContext;
	}

	public async Task<Auction?> GetCurrent()
	{
		var now = DateTime.UtcNow;
		return await _dbContext
			.Auctions
			.FirstOrDefaultAsync(user => user.StartsAt <= now && user.EndsAt >= now);
	}
}
