using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using TaskManager.Application.DTOs;

namespace TaskManager.WebAPI.Endpoints;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/authentication")
            .WithTags("Authentication")
            .AllowAnonymous()
            .WithOpenApi();

        group.MapPost("/login", LoginAsync)
             .WithSummary("Login")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status401Unauthorized);

        group.MapPost("/logout", (Delegate)LogoutAsync)
             .WithSummary("Logout")
             .Produces(StatusCodes.Status200OK);
    }

    static async Task<IResult> LoginAsync(
        HttpContext http, Login loginRequest)
    {
        if(loginRequest.Email == "admin@admin.com" && loginRequest.Password == "123456")
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, loginRequest.Email),
                new(ClaimTypes.Role, "Admin")
            };

            var identity = new ClaimsIdentity(claims, "cookie-auth");
            var principal = new ClaimsPrincipal(identity);

            await http.SignInAsync("cookie-auth", principal);

            return TypedResults.Ok(
                new { message = "Logado com sucesso." }
            );
        }

        return TypedResults.Unauthorized();
    }

    static async Task<IResult> LogoutAsync(HttpContext http)
    {
        await http.SignOutAsync("cookie-auth");
        return TypedResults.Ok(
            new { message = "Deslogado com sucesso." }
        );
    }
}
