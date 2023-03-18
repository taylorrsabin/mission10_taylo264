using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mission10.Models;

namespace mission10
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);
            });

            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

            //Enable Razor Pages
            services.AddRazorPages();

            //Add sessions
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //Enable sessions and routing
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // First check if category is selected and page number
                endpoints.MapControllerRoute(
                    "typepage",
                    "{bookType}/Page{pageNum}",
                    new { Controller = "Home", action = "Index" });

                //Next check for just page number
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index" }
                    );

                //Next Check for just category
                endpoints.MapControllerRoute("type", "{Category}", new { Controller = "Home", action = "Index", pageNum = 1 });

                //Default
                endpoints.MapDefaultControllerRoute();

                //Enable razor pages
                endpoints.MapRazorPages();
            });
        }
    }
}

