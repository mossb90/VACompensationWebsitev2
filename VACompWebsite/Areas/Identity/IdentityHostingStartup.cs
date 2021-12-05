using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VACompWebsite.Areas.Identity.Data;
using VACompWebsite.Data;

[assembly: HostingStartup(typeof(VACompWebsite.Areas.Identity.IdentityHostingStartup))]
namespace VACompWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DBAuthContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DBAuthContextConnection")));

                services.AddDefaultIdentity<VACompUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<DBAuthContext>();
            
            });
        }
    }
}