using System;
using H5ServersideSHS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(H5ServersideSHS.Areas.Identity.IdentityHostingStartup))]
namespace H5ServersideSHS.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<H5ServersideSHSContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("H5ServersideSHSContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<H5ServersideSHSContext>();
            });
        }
    }
}