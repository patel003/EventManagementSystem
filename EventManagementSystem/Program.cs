using Microsoft.AspNetCore.Authentication.Cookies;

namespace EventManagementSystem
{

    public class Progran
    {

        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);
            //Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Auth/Login";
                   options.AccessDeniedPath = "/Auth/Login";
               });
            builder.Services.AddAuthentication();

            var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days.You may want to change this for production scenarios, see https:/laka.nms/aspnetcore-hsts app.UseHsts)；
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Auth}/{action=Login}/{Id?}")
            .WithStaticAssets();
            app.Run();

           
        }

    }

}