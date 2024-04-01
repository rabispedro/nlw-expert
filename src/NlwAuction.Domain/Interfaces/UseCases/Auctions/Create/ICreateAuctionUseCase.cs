using NlwAuction.Domain.Dtos.Auctions.Requests;
using NlwAuction.Domain.Dtos.Auctions.Responses;

namespace NlwAuction.Domain.Interfaces.UseCases.Auctions.Create;

public interface ICreateAuctionUseCase
{
	Task<AuctionResponseDto> Execute(AuctionRequestDto request);
}
