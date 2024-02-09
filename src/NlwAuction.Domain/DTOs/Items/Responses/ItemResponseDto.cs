using NlwAuction.Domain.DTOs.Auctions.Responses;
using NlwAuction.Domain.Enums;

namespace NlwAuction.Domain.DTOs.Items.Responses;

public record ItemResponseDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public string Brand { get; init; } = string.Empty;
	public ConditionEnums Condition { get; init; }
	public decimal BasePrice { get; init; }
	public Guid AuctionId { get; init; }
	public DateTime CreatedAt { get; init; }
	public DateTime UpdatedAt { get; init; }
}
