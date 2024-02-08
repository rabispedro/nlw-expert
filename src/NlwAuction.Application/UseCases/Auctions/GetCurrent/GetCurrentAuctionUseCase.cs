using NlwAuction.Application.UseCases.Interfaces;
using NlwAuction.Application.UseCases.Interfaces.Auctions.GetCurrent;
using NlwAuction.Domain.Entities;

namespace NlwAuction.Application.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase : IGetCurrentAuctionUseCase
{
	public Auction Execute()
	{
		return new Auction { StartsAt = DateTime.UtcNow, EndsAt = DateTime.UtcNow.AddHours(3) };
	}

	Task IBaseUseCase.Execute()
	{
		throw new NotImplementedException();
	}
}
