using NlwAuction.Domain.Enums;

namespace NlwAuction.Domain.Dtos.Items.Responses;

public record ItemResponseDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public string Brand { get; init; } = string.Empty;
	public ItemConditionEnums Condition { get; init; }
	public decimal BasePrice { get; init; }
	public Guid AuctionId { get; init; }
	public DateTime CreatedAt { get; init; }
	public DateTime UpdatedAt { get; init; }
}

