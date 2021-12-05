using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VACompWeb.Areas.Identity.Data;
using VACompWeb.Data;

[assembly: HostingStartup(typeof(VACompWeb.Areas.Identity.IdentityHostingStartup))]
namespace VACompWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<VAAuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("VAAuthDbContextConnection")));

                services.AddDefaultIdentity<VAUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<VAAuthDbContext>();
            });
        }
    }
}