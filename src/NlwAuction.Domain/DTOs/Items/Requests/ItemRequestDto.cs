using NlwAuction.Domain.Enums;

namespace NlwAuction.Domain.DTOs.Items.Requests;

public record ItemRequestDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public string Brand { get; init; } = string.Empty;
	public ConditionEnums Condition { get; init; }
	public decimal BasePrice { get; init; }
	public Guid AuctionId { get; init; }
}
