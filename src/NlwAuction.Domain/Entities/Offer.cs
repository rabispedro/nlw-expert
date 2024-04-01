namespace NlwAuction.Domain.Entities;

public class Offer : BaseEntity
{
	public Guid ItemId { get; set; }
	public virtual Item? Item { get; set; }
	public Guid UserId { get; set; }
	public virtual User? User { get; set; }
	public decimal Price { get; set; }
}
