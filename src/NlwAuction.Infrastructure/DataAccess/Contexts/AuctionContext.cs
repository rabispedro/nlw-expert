using Microsoft.EntityFrameworkCore;
using NlwAuction.Domain.Entities;

namespace NlwAuction.Infrastructure.DataAccess.Contexts;

public sealed class AuctionContext : DbContext
{
	public AuctionContext(DbContextOptions<AuctionContext> options) : base(options) {}

	public DbSet<Auction> Auctions { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseNpgsql("Server=localhost;Port=8000;Database=nlw_auction_db;Uid=nlw_auction_user;Pwd=nlwAuctionP455");
	}
}
