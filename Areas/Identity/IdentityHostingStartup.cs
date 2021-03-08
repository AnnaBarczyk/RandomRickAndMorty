using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RandomRickAndMorty.Areas.Identity.Data;
using RandomRickAndMorty.Data;

[assembly: HostingStartup(typeof(RandomRickAndMorty.Areas.Identity.IdentityHostingStartup))]
namespace RandomRickAndMorty.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<RandomRickAndMortyContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RandomRickAndMortyContextConnection")));

                services.AddIdentity<RandomRickAndMortyUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<RandomRickAndMortyContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();
            });
        }
    }
}