using Hospital.DAL.DataBase;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Enhancement ConnectionString
            var connectionString = builder.Configuration.GetConnectionString("defaultConnection");

            builder.Services.AddDbContext<HospitalDbContext>(options =>
            options.UseSqlServer(connectionString));

            //Identity Configuration 
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });

            builder.Services.AddIdentityCore<Patient>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<HospitalDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<Patient>>(TokenOptions.DefaultProvider);

            builder.Services.AddIdentityCore<Staff>(options => options.SignIn.RequireConfirmedAccount = true)
              .AddEntityFrameworkStores<HospitalDbContext>()
              .AddTokenProvider<DataProtectorTokenProvider<Staff>>(TokenOptions.DefaultProvider);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
