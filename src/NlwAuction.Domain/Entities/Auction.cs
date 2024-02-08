using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace NlwAuction.Domain.Entities;

[Table("tbl_auction")]
public class Auction : BaseEntity
{

	[Column("name")]
	[Required]
	[MinLength(16)]
	[MaxLength(255)]
	[NotNull]
	public string Name { get; set; } = string.Empty;

	[Column("starts_at")]
	[Required]
	public DateTime StartsAt { get; set; }

	[Column("ends_at")]
	[Required]
	public DateTime EndsAt { get; set; }

	public ICollection<Item> Items { get; set; } = new List<Item>();
}
