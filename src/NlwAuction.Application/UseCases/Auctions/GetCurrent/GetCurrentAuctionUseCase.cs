using AutoMapper;
using NlwAuction.Domain.Dtos.Auctions.Responses;
using NlwAuction.Domain.Interfaces.DataAccess.Repositories;
using NlwAuction.Domain.Interfaces.UseCases.Auctions.GetCurrent;

namespace NlwAuction.Application.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase : IGetCurrentAuctionUseCase
{
	private readonly IAuctionRepository _auctionRepository;
	private readonly IMapper _mapper;

	public GetCurrentAuctionUseCase(
		IAuctionRepository auctionRepository,
		IMapper mapper)
	{
		ArgumentNullException.ThrowIfNull(auctionRepository);
		ArgumentNullException.ThrowIfNull(mapper);

		_auctionRepository = auctionRepository;
		_mapper = mapper;
	}

	public async Task<AuctionResponseDto> Execute()
	{
		var auction = await _auctionRepository.GetCurrent();
		return _mapper.Map<AuctionResponseDto>(auction);
	}
}
