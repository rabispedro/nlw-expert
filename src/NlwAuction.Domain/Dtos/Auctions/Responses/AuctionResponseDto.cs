using System.Collections.Immutable;
using System.Collections.ObjectModel;
using NlwAuction.Domain.Dtos.Items.Responses;

namespace NlwAuction.Domain.Dtos.Auctions.Responses;

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
