using Microsoft.AspNetCore.Authentication.Cookies;
using Turismo.Modelos;
using TurismoAPI.Consumer;

namespace TurismoMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Crud<TouristTicket>.EndPoint = "https://localhost:7185/api/TouristTickets";
            Crud<UserAdmin>.EndPoint = "https://localhost:7185/api/UserAdmins";
            Crud<CategoryTicket>.EndPoint = "https://localhost:7185/api/CategoryTickets";
            Crud<UserClient>.EndPoint = "https://localhost:7185/api/UserClients";
            Crud<Payment>.EndPoint = "https://localhost:7185/api/Payments";
            Crud<PaymentTicket>.EndPoint = "https://localhost:7185/api/PaymentTickets";
            Crud<TouristRoute>.EndPoint = "https://localhost:7185/api/TouristRoutes";
            Crud<SeatCategory>.EndPoint = "https://localhost:7185/api/SeatCategories";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache();

            // Configuración de la sesión
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Duración de la sesión
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //// Configuración de autenticación con cookies
            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = "/Login/Login";  // Definir la ruta de login
            //        options.LogoutPath = "/Login/Logout";  // Definir la ruta de logout
            //        options.AccessDeniedPath = "/Home/AccessDenied"; // Definir la ruta para acceso denegado
            //    });

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
