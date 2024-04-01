using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NlwAuction.Domain.Entities;

namespace NlwAuction.Infrastructure.DataAccess.Configuration;

public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
{
	public void Configure(EntityTypeBuilder<Auction> builder)
	{
		ArgumentNullException.ThrowIfNull(builder);

		builder
			.ToTable("tbl_auction")
			.HasKey(entity => entity.Id);

		builder
			.Property(entity => entity.Id)
			.HasColumnName("id")
			.IsRequired();

		builder
			.Property(entity => entity.Name)
			.HasColumnName("name")
			.HasMaxLength(255)
			.IsRequired();
		
		builder
			.Property(entity => entity.StartsAt)
			.HasColumnName("starts_at")
			.IsRequired();
		
		builder
			.Property(entity => entity.EndsAt)
			.HasColumnName("ends_at")
			.IsRequired();

		builder
			.HasMany(entity => entity.Items)
			.WithOne(item => item.Auction)
			.HasForeignKey(item => item.AuctionId)
			.OnDelete(DeleteBehavior.SetNull);

		builder
			.Property(entity => entity.CreatedAt)
			.HasColumnName("created_at")
			.ValueGeneratedOnAdd();

		builder
			.Property(entity => entity.UpdatedAt)
			.HasColumnName("updated_at")
			.ValueGeneratedOnUpdate();
	}
}
