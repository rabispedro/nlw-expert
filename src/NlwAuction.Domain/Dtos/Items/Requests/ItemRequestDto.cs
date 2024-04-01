using NlwAuction.Domain.Enums;

namespace NlwAuction.Domain.Dtos.Items.Requests;

public record ItemRequestDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public string Brand { get; init; } = string.Empty;
	public ItemConditionEnums Condition { get; init; }
	public decimal BasePrice { get; init; }
	public Guid AuctionId { get; init; }
}