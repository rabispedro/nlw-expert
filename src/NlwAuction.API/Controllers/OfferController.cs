using Microsoft.AspNetCore.Mvc;
using NlwAuction.API.Filters;
using NlwAuction.Domain.Dtos.Offers.Requests;
using NlwAuction.Domain.Dtos.Offers.Responses;
using NlwAuction.Domain.Interfaces.UseCases.Offers.CreateOffer;

namespace NlwAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : AbstractBaseController
{
	private readonly ICreateOfferUseCase _createOfferUseCase;

	public OfferController(ICreateOfferUseCase createOfferUseCase)
	{
		ArgumentNullException.ThrowIfNull(createOfferUseCase);
		
		_createOfferUseCase = createOfferUseCase;
	}

	[HttpPost]
	[Route("{itemId}")]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<OfferResponseDto>> Create(
		[FromRoute] Guid itemId,
		[FromBody] OfferRequestDto request)
	{
		return Created(string.Empty, await _createOfferUseCase.Execute(itemId, request));
	}
}
