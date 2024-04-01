using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NlwAuction.Domain.Entities;

namespace NlwAuction.Infrastructure.DataAccess.Configuration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
	public void Configure(EntityTypeBuilder<Item> builder)
	{
		ArgumentNullException.ThrowIfNull(builder);

		builder
			.ToTable("tbl_item")
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
			.Property(entity => entity.Brand)
			.HasColumnName("brand")
			.HasMaxLength(255)
			.IsRequired();
		
		builder
			.Property(entity => entity.Condition)
			.HasColumnName("condition")
			.IsRequired();

		builder
			.Property(entity => entity.BasePrice)
			.HasColumnName("base_price")
			.IsRequired();

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