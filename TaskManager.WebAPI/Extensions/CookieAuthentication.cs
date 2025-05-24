namespace TaskManager.WebAPI.Extensions;

public static class CookieAuthentication
{
    public static IServiceCollection AddCookieAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication("cookie-auth")
            .AddCookie("cookie-auth", options =>
            {
                options.Cookie.Name = "task_auth";
                options.LoginPath = "/login"; 
                options.AccessDeniedPath = "/denied"; 
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.SlidingExpiration = true;
            });

        return services;
    }
}
