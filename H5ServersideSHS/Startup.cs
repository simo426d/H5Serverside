using H5ServersideSHS.Areas.Identity.Code;
using H5ServersideSHS.Areas.ToDoList.Code;
using H5ServersideSHS.Areas.ToDoList.Models;
using H5ServersideSHS.Code;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H5ServersideSHS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<Class1>();
            services.AddTransient<HashingExample1>();
            services.AddTransient<BcryptExample2>();
            services.AddTransient<CryptExample3>();
            services.AddTransient<SQLQueries>();
            services.AddTransient<Crypt>();

            services.AddDataProtection();

            services.AddTransient<MyUserRoleHandler>();

            var connection = Configuration.GetConnectionString("ToDoServerContextConnector");
            services.AddDbContext<ToDoServerContext>(options => options.UseSqlServer(connection));

            // Dette svarer til at man instantiere objekter ovenover.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
