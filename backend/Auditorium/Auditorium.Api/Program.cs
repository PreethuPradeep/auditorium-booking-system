
using Auditorium.Api.Database;
using Auditorium.Api.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Auditorium.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<BookingService>();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddControllers();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(Options =>
                 {
                     Options.LoginPath = "/api/auth/login";
                     Options.LogoutPath = "/api/auth/logout";
                     Options.ExpireTimeSpan = TimeSpan.FromHours(8);
                     Options.SlidingExpiration = true;
                     Options.Cookie.HttpOnly = true;
                     Options.Cookie.SameSite = SameSiteMode.Strict;
                     Options.Cookie.SecurePolicy = CookieSecurePolicy.None;

                     Options.Events.OnRedirectToLogin = context =>
                     {
                         context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                         return Task.CompletedTask;
                     };
                     Options.Events.OnRedirectToAccessDenied = context =>
                     {
                         context.Response.StatusCode = StatusCodes.Status403Forbidden;
                         return Task.CompletedTask;
                     };
                 });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            //seed manager user
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (!db.Users.Any())
                {
                    db.Users.AddRange(new Models.User
                    {
                        Email = "manager@royal.com",
                        PasswordHash = "manager123",
                        Role = "Manager"
                    },
                    new Models.User
                    {
                        Email = "sysadmin@royal.com",
                        PasswordHash = "admin123",
                        Role = "SysAdmin"
                    });
                    db.SaveChanges();
                }
            }

            app.Run();
        }
    }
}
