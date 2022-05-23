using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Warehouse.api.Areas.Identity.IdentityHostingStartup))]

namespace Warehouse.api.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}