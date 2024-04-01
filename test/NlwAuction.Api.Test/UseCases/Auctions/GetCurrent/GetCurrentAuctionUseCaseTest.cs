using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using FluentAssertions;
using NlwAuction.Application.UseCases.Auctions.GetCurrent;
using NlwAuction.Domain.Entities;
using NlwAuction.Domain.Enums;
using NlwAuction.Domain.Interfaces.DataAccess.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace NlwAuction.Api.Test.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCaseTest
{
	[Fact]
	public async Task GetCurrentSuccessRandomAuction()
	{
		//	ARRANGE
		var fakeAuction = new Faker<Auction>()
			.RuleFor(auction => auction.Id, fake => fake.Database.Random.Guid())
			.RuleFor(auction => auction.Name, fake => fake.Lorem.Word())
			.RuleFor(auction => auction.Items, (fake, auction) => new List<Item>
			{
				new()
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
				}
			})
			.RuleFor(auction => auction.StartsAt, fake => fake.Date.Past())
			.RuleFor(auction => auction.EndsAt, fake => fake.Date.Future())
			.RuleFor(auction => auction.CreatedAt, fake => fake.Date.LocalSystemClock())
			.RuleFor(auction => auction.UpdatedAt, fake => fake.Date.Soon())
			.Generate();

		var auctionRepository = Substitute.For<IAuctionRepository>();
		auctionRepository.GetCurrent().Returns(fakeAuction);

		var mapper = Substitute.For<IMapper>();

		var useCase = new GetCurrentAuctionUseCase(auctionRepository, mapper);

		//	ACT
		var auction = await useCase.Execute();

		//	ASSERT
		auction.Should().NotBeNull();
		auction.Id.Should().Be(fakeAuction.Id);
		auction.Name.Should().Be(fakeAuction.Name);
		auction.StartsAt.Should().Be(fakeAuction.StartsAt);
		auction.EndsAt.Should().Be(fakeAuction.EndsAt);
		auction.UpdatedAt.Should().Be(fakeAuction.UpdatedAt);
	}

	[Fact]
	public async Task GetCurrentSuccessNullAuction()
	{
		//	ARRANGE
		var auctionRepository = Substitute.For<IAuctionRepository>();
		auctionRepository.GetCurrent().ReturnsNull();

		var mapper = Substitute.For<IMapper>();

		var useCase = new GetCurrentAuctionUseCase(auctionRepository, mapper);

		//	ACT
		var auction = await useCase.Execute();

		//	ASSERT
		auction.Should().BeNull();
	}
}
