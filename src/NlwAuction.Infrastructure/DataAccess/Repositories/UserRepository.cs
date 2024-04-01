
using Microsoft.EntityFrameworkCore;
using NlwAuction.Domain.Entities;
using NlwAuction.Domain.Interfaces.DataAccess.Repositories;
using NlwAuction.Infrastructure.DataAccess.Contexts;

namespace NlwAuction.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
	private readonly NlwAuctionDbContext _dbContext;

	public UserRepository(NlwAuctionDbContext dbContext)
	{
		ArgumentNullException.ThrowIfNull(dbContext);
		
		_dbContext = dbContext;
	}

	public async Task<bool> Exists(string email)
	{
		return await _dbContext.Users.AnyAsync(user => user.Email == email);
	}

	public async Task<bool> Exists(Guid id)
	{
		return await _dbContext.Users.AnyAsync(user => user.Id == id);
	}

	public async Task<User?> FindByEmail(string email)
	{
		return await _dbContext.Users.Where(user => user.Email == email).FirstOrDefaultAsync();
	}

	public async Task<User?> FindById(Guid id)
	{
		return await _dbContext.Users.FindAsync(id);
	}
}
