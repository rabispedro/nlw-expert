using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using NlwAuction.Domain.Entities;
using NlwAuction.Domain.Interfaces.DataAccess.Repositories;

namespace NlwAuction.Application.Contexts;

public class UserContext
{
	private readonly IHttpContextAccessor _httpContextAccessor;
	private readonly IUserRepository _userRepository;
	private User? _user;
	private ICollection<Claim> _claims = new List<Claim>();

	public UserContext(
		IHttpContextAccessor httpContextAccessor,
		IUserRepository userRepository)
	{
		ArgumentNullException.ThrowIfNull(httpContextAccessor);
		ArgumentNullException.ThrowIfNull(userRepository);
		
		_httpContextAccessor = httpContextAccessor;
		_userRepository = userRepository;
	}

	public async Task<User> GetLoggedUser()
	{
		var token = ExtractBearerToken();
		var tokenParsed = ParseBearerToken(token);
		var userEntity = await _userRepository.FindById(new Guid(tokenParsed.UserId)) ?? throw new InvalidDataException("User logged not found!");
		_user = userEntity ?? _user;

		return _user;
	}

		public async Task<User> GetLoggedUser(string token)
	{
		var tokenParsed = ParseBearerToken(token);
		var userEntity = await _userRepository.FindById(new Guid(tokenParsed.UserId)) ?? throw new InvalidDataException("User logged not found!");
		_user = userEntity ?? _user;

		return _user;
	}

	public async Task<ReadOnlyCollection<Claim>> GetLoggedUserClaims()
	{
		await GetLoggedUser();

		foreach (var role in tokenParsed.Roles)
		{
			var userClaim = new Claim(role.name, role.value);
			_claims.Add(userClaim);
		}

		return new ReadOnlyCollection<Claim>(_claims.ToImmutableList());
	}

	private string ExtractBearerToken()
	{
		var bearerToken = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"].ToString();

		if (string.IsNullOrWhiteSpace(bearerToken))
			throw new InvalidOperationException("Bearer Token missing.");

		return bearerToken.Replace("Bearer ", "");
	}

	private static Dictionary<string, Claim> ParseBearerToken(string token)
	{
		var dict = new Dictionary<string, Claim>();

		var tokenSplitted = token.Split(" ");

		foreach(var item in tokenSplitted)
		{
			dict.Add(item, item);
		}

		return dict;
	}
}
