using System;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using NlwAuction.Application.UseCases.Offers.CreateOffer;
using NlwAuction.Domain.Dtos.Offers.Requests;
using NlwAuction.Domain.Entities;
using NlwAuction.Domain.Interfaces.DataAccess.Repositories;
using NlwAuction.Domain.Interfaces.UseCases.Offers.CreateOffer;
using NSubstitute;
using Xunit;

namespace NlwAuction.Api.Test.UseCases.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{

	[Fact]
	public async Task CreateOfferSuccessPricedOffer()
	{
		//	ARRANGE
		var fakeRequest = new Faker<OfferRequestDto>()
			.RuleFor(request => request.Price, fake => fake.Random.Decimal(1.0M, 1000.0M))
			.Generate();

		var fakeOffer = new Faker<Offer>()
			.RuleFor(offer => offer.Id, fake => fake.Database.Random.Guid())
			.RuleFor(offer => offer.Item, fake => new Item
			{
				Id = fake.Database.Random.Guid(),
				Name = fake.Commerce.ProductName(),
				Brand = fake.Commerce.Department(),
				BasePrice = fake.Random.Decimal(50.0M, 200.0M),
				ImageUrl = fake.Lorem.Word(),
				Condition = fake.PickRandom<ItemConditionEnums>(),
				Auction = auction,
				AuctionId = auction.Id,
				CreatedAt = fake.Date.Past(),
				UpdatedAt = fake.Date.Soon()
			})
			.RuleFor(offer => offer.CreatedAt, )
			.RuleFor(offer => offer.CreatedAt, )
			.RuleFor(offer => offer.CreatedAt, )
			.RuleFor(offer => offer.CreatedAt, )
			.Generate();



		var fakeAuction = new Faker<Auction>()
			.RuleFor(auction => auction.Id, fake => fake.Database.Random.Guid())
			.RuleFor(auction => auction.Name, fake => fake.Lorem.Word())
			.RuleFor(auction => auction.Items, (fake, auction) => new List<Item>
			{
				new()
				{

				}
			})
			.RuleFor(auction => auction.StartsAt, fake => fake.Date.Past())
			.RuleFor(auction => auction.EndsAt, fake => fake.Date.Future())
			.RuleFor(auction => auction.CreatedAt, fake => fake.Date.LocalSystemClock())
			.RuleFor(auction => auction.UpdatedAt, fake => fake.Date.Soon())
			.Generate();

		var mapper = Substitute.For<IMapper>();
		mapper.Map<Offer>(fakeRequest).Returns(fakeOffer);
		mapper.Map<OfferRequestDto>(fakeOffer).Returns(fakeRequest);

		var offerRepository = Substitute.For<IOfferRepository>();
		offerRepository.Add(fakeRequest).Returns(fakeRequest);

		Task<OfferResponseDto> Execute(Guid itemId, OfferRequestDto request);




		var useCase = new CreateOfferUseCase(offerRepository, mapper);

		//	ACT
		var auction = await useCase.Execute(fakeItemId, fakeRequest);

		//	ASSERT
		auction.Should().NotBeNull();
		auction.Id.Should().Be(fakeAuction.Id);
		auction.Name.Should().Be(fakeAuction.Name);
		auction.StartsAt.Should().Be(fakeAuction.StartsAt);
		auction.EndsAt.Should().Be(fakeAuction.EndsAt);
		auction.UpdatedAt.Should().Be(fakeAuction.UpdatedAt);
	}
}
