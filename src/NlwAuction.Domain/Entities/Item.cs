using System.ComponentModel.DataAnnotations.Schema;

namespace NlwAuction.Domain.Entities;

[Table("tbl_item")]
public class Item : BaseEntity
{
	[Column("name")]
	public string Name { get; set; } = string.Empty;
	[Column("brand")]
	public string Brand { get; set; } = string.Empty;
	[Column("condition")]
	public int Condition { get; set; }
	[Column("base_price")]
	public decimal BasePrice { get; set; }
	[Column("auction_id")]
	public Guid AuctionId { get; set; }

	[ForeignKey("AuctionId")]
	public virtual Auction Auction { get; set; }
}
