using NlwAuction.Domain.Dtos.Auctions.Responses;

namespace NlwAuction.Domain.Interfaces.UseCases.Auctions.GetCurrent;

public interface IGetCurrentAuctionUseCase
{
	Task<AuctionResponseDto> Execute();
}
