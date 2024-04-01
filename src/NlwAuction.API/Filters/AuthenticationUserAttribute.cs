using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NlwAuction.Application.Contexts;

namespace NlwAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
	private readonly UserContext _userContext;

	public AuthenticationUserAttribute(UserContext userContext) : base()
	{
		ArgumentNullException.ThrowIfNull(userContext);

		_userContext = userContext;
	}

	public async void OnAuthorization(AuthorizationFilterContext context)
	{
		try
		{
			var token = ExtractBearerToken(context.HttpContext);
			var loggedUser = await _userContext.GetLoggedUser(token);

			if (!string.IsNullOrWhiteSpace(loggedUser.Email))
			{
				context.Result = new UnauthorizedObjectResult("Email not valid.");
			}
		}
		catch (Exception ex)
		{
			context.Result = new UnauthorizedObjectResult(ex.Message);
			throw new AuthenticationFailureException(ex.Message);
		}
	}

	private static string ExtractBearerToken(HttpContext context)
	{
		var bearerToken = context.Request.Headers.Authorization.ToString();

		if (string.IsNullOrWhiteSpace(bearerToken))
			throw new InvalidOperationException("Bearer Token missing.");

		return bearerToken.Replace("Bearer ", "");
	}
}
