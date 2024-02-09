using NlwAuction.Domain.DTOs.Items.Responses;

namespace NlwAuction.Domain.DTOs.Auctions.Responses;

public record AuctionResponseDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public DateTime StartsAt { get; init; }
	public DateTime EndsAt { get; init; }
	public ICollection<ItemResponseDto> Items { get; init; } = new List<ItemResponseDto>();
	public DateTime CreatedAt { get; init; }
	public DateTime UpdatedAt { get; init; }
}
