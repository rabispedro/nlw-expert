using AutoMapper;
using NlwAuction.Application.Contexts;
using NlwAuction.Domain.Dtos.Offers.Requests;
using NlwAuction.Domain.Dtos.Offers.Responses;
using NlwAuction.Domain.Entities;
using NlwAuction.Domain.Interfaces.DataAccess.Repositories;
using NlwAuction.Domain.Interfaces.UseCases.Offers.CreateOffer;

namespace NlwAuction.Application.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase : ICreateOfferUseCase
{
	private readonly UserContext _userContext;
	private readonly IOfferRepository _offerRepository;
	private readonly IMapper _mapper;

	public CreateOfferUseCase(
		UserContext userContext,
		IOfferRepository offerRepository,
		IMapper mapper)
	{
		ArgumentNullException.ThrowIfNull(userContext);
		ArgumentNullException.ThrowIfNull(offerRepository);
		ArgumentNullException.ThrowIfNull(mapper);

		_userContext = userContext;
		_offerRepository = offerRepository;
		_mapper = mapper;
	}

	public async Task<OfferResponseDto> Execute(Guid itemId, OfferRequestDto request)
	{
		var loggedUser = await _userContext.GetLoggedUser();
		
		var offer = new Offer
		{
			CreatedAt = DateTime.UtcNow,
			ItemId = itemId,
			Price = request.Price,
			UserId = loggedUser.Id
		};

		await _offerRepository.Add(offer);
		return _mapper.Map<OfferResponseDto>(offer);
	}
}
