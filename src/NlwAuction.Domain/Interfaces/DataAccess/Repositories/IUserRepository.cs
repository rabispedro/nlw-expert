using NlwAuction.Domain.Entities;

namespace NlwAuction.Domain.Interfaces.DataAccess.Repositories;

public interface IUserRepository
{
	Task<bool> Exists(string email);
	Task<bool> Exists(Guid id);
	Task<User?> FindById(Guid id);
	Task<User?> FindByEmail(string email);
}
