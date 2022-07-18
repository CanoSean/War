using Microsoft.EntityFrameworkCore;
using War.Data;

namespace War.Areas.Identity.Data
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WarDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WarDBContext")));

                services.AddDefaultIdentity<WarUser>()
                    .AddEntityFrameworkStores<WarDBContext>();
            });
        }
    }
}
