using NlwAuction.Domain.Entities;

namespace NlwAuction.Domain.Interfaces.Auctions.UseCases;

public interface IGetCurrentAuctionUseCase
{
	public Auction Execute();
}
