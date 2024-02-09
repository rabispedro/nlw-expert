namespace NlwAuction.Domain.Entities;

public class Auction : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public DateTime StartsAt { get; set; }
	public DateTime EndsAt { get; set; }
	public ICollection<Item> Items { get; set; } = new List<Item>();
}
