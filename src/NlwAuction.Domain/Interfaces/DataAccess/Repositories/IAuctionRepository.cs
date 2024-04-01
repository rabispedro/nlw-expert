using NlwAuction.Domain.Entities;

namespace NlwAuction.Domain.Interfaces.DataAccess.Repositories;

public interface IAuctionRepository
{
	Task<Auction?> GetCurrent();
}
