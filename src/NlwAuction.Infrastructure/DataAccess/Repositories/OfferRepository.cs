using NlwAuction.Domain.Entities;
using NlwAuction.Domain.Interfaces.DataAccess.Repositories;
using NlwAuction.Infrastructure.DataAccess.Contexts;

namespace NlwAuction.Infrastructure.DataAccess.Repositories;

public class OfferRepository : IOfferRepository
{
	private readonly NlwAuctionDbContext _dbContext;
	public OfferRepository(NlwAuctionDbContext dbContext)
	{
		ArgumentNullException.ThrowIfNull(dbContext);

		_dbContext = dbContext;
	}

	public async Task Add(Offer offer)
	{
		await _dbContext.Offers.AddAsync(offer);
		await _dbContext.SaveChangesAsync();
	}

	public Task<Offer> Save(Offer offer)
	{
		throw new NotImplementedException();
	}
}
