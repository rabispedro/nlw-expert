using Microsoft.AspNetCore.Mvc.Filters;
using NlwAuction.API.Filters;
using NlwAuction.Application.Contexts;
using NlwAuction.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddUseCases();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddScoped<IAuthorizationFilter, AuthenticationUserAttribute>();
builder.Services.AddSingleton<UserContext>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHealthChecks("api/v1/health-checks");

app.MapControllers();

app.Run();
