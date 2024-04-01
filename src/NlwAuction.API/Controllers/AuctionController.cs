using Microsoft.AspNetCore.Mvc;
using NlwAuction.API.Controllers;
using NlwAuction.Domain.Dtos.Auctions.Requests;
using NlwAuction.Domain.Dtos.Auctions.Responses;
using NlwAuction.Domain.Interfaces.UseCases.Auctions.Create;
using NlwAuction.Domain.Interfaces.UseCases.Auctions.GetCurrent;

namespace NlwAuction.Api.Controllers;

public class AuctionController : AbstractBaseController
{
	private readonly IGetCurrentAuctionUseCase _getCurrentAuctionUseCase;
	private readonly ICreateAuctionUseCase _createAuctionUseCase;

	public AuctionController(
		IGetCurrentAuctionUseCase getCurrentAuctionUseCase,
		ICreateAuctionUseCase createAuctionUseCase)
	{
		ArgumentNullException.ThrowIfNull(getCurrentAuctionUseCase);
		ArgumentNullException.ThrowIfNull(createAuctionUseCase);

		_getCurrentAuctionUseCase = getCurrentAuctionUseCase;
		_createAuctionUseCase = createAuctionUseCase;
	}

	[HttpGet]
	[ProducesResponseType(typeof(AuctionResponseDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<AuctionResponseDto>> GetCurrent() =>
		Ok(await _getCurrentAuctionUseCase.Execute());

	[HttpPost("")]
	public async Task<IActionResult> Create([FromBody] AuctionRequestDto request) =>
		Created("", await _createAuctionUseCase.Execute(request).ToString());
}
