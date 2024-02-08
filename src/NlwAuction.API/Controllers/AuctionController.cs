using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NlwAuction.Application.UseCases.Interfaces.Auctions.GetCurrent;
using NlwAuction.Domain.Entities;

namespace NlwAuction.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuctionController : ControllerBase
{
	private readonly IGetCurrentAuctionUseCase _getCurrentAuctionUseCase;

	public AuctionController(IGetCurrentAuctionUseCase getCurrentAuctionUseCase)
	{
		_getCurrentAuctionUseCase = getCurrentAuctionUseCase ?? throw new ArgumentNullException(nameof(getCurrentAuctionUseCase));
	}

	[HttpGet]
	[ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetCurrentAuction() =>
		Ok(_getCurrentAuctionUseCase.Execute());

	// [HttpGet]
	// public async Task<IActionResult> Get
}
