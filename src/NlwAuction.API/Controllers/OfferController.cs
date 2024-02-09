using Microsoft.AspNetCore.Mvc;
using NlwAuction.Domain.DTOs.Offers.Requests;

namespace NlwAuction.API.Controllers;

public class OfferController : AbstractBaseController
{
	private readonly ICreateOfferUseCase _createOfferUseCase;

	public OfferController(ICreateOfferUseCase createOfferUseCase)
	{
		_createOfferUseCase = createOfferUseCase ?? throw new ArgumentNullException(nameof(createOfferUseCase));
	}
	
	[HttpPost("{itemId}")]
	public async Task<IActionResult> Create(
		[FromRoute] Guid itemId,
		[FromBody] OfferRequestDto request) =>
			Created("", _createOfferUseCase.Execute());
	
}
