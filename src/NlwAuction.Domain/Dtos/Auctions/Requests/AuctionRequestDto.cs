using System.Collections.Immutable;
using NlwAuction.Domain.Dtos.Items.Requests;

namespace NlwAuction.Domain.Dtos.Auctions.Requests;

public record AuctionRequestDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public DateTime StartsAt { get; init; }
	public DateTime EndsAt { get; init; }
	public ICollection<ItemRequestDto> Items { get; init; } = new List<ItemRequestDto>();
}
