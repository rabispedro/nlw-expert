using Microsoft.AspNetCore.Mvc;
using NlwAuction.API.Controllers;
using NlwAuction.Application.UseCases.Interfaces.Auctions.GetCurrent;
using NlwAuction.Domain.DTOs.Auctions.Requests;
using NlwAuction.Domain.DTOs.Auctions.Responses;
using NlwAuction.Domain.Entities;

namespace NlwAuction.Api.Controllers;

public class AuctionController : AbstractBaseController
{
	private readonly IGetCurrentAuctionUseCase _getCurrentAuctionUseCase;

	public AuctionController(IGetCurrentAuctionUseCase getCurrentAuctionUseCase)
	{
		_getCurrentAuctionUseCase = getCurrentAuctionUseCase ?? throw new ArgumentNullException(nameof(getCurrentAuctionUseCase));
	}

	[HttpGet]
	[ProducesResponseType(typeof(AuctionResponseDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetCurrent() =>
		Ok(_getCurrentAuctionUseCase.Execute());

	[HttpPost("")]
	public async Task<IActionResult> Create([FromBody] AuctionRequestDto request) =>
		Created("", "");
}
