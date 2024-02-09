using NlwAuction.Domain.Enums;

namespace NlwAuction.Domain.Entities;

public class Item : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public string Brand { get; set; } = string.Empty;
	public ConditionEnums Condition { get; set; }
	public decimal BasePrice { get; set; }
	public Guid AuctionId { get; set; }
	public virtual Auction? Auction { get; set; }
}
