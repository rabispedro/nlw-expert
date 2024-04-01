using Microsoft.EntityFrameworkCore;
using NlwAuction.Domain.Entities;

namespace NlwAuction.Infrastructure.DataAccess.Contexts;

public class NlwAuctionDbContext : DbContext
{
	public NlwAuctionDbContext() : base() {}
	public NlwAuctionDbContext(DbContextOptions options) : base(options) {}

	public DbSet<Auction> Auctions { get; set; }
	public DbSet<Offer> Offers { get; set; }
	public DbSet<User> Users { get; set; }
}
