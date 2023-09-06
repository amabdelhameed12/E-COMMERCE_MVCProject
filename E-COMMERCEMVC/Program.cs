using E_COMMERCEMVC.Models;
using E_COMMERCEMVC.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_COMMERCEMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Context>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

            builder.Services.AddAuthentication().AddCookie();

            builder.Services.AddScoped<IProduct, ProductRepository>();
            builder.Services.AddScoped<ICategory, CategoryRepository>();
            builder.Services.AddScoped<IOrder, OrderRepository>();
            builder.Services.AddScoped<ICartItem, CartItemRepository>();
            builder.Services.AddScoped<ILogin, CostomerRepository>();
            builder.Services.AddScoped<ILogin, CostomerRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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