using NlwAuction.Domain.Entities;

namespace NlwAuction.Application.UseCases.Interfaces.Auctions.GetCurrent;

public interface IGetCurrentAuctionUseCase : IBaseUseCase
{
	public Auction Execute();
}
