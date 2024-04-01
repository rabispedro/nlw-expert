using NlwAuction.Domain.Dtos.Offers.Requests;
using NlwAuction.Domain.Dtos.Offers.Responses;

namespace NlwAuction.Domain.Interfaces.UseCases.Offers.CreateOffer;

public interface ICreateOfferUseCase
{
	Task<OfferResponseDto> Execute(Guid itemId, OfferRequestDto request);
}
