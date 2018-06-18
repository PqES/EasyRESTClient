using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MsProduct.DAO;
using Pivotal.Discovery.Client;
using System.Reflection;

namespace MsProduct
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
            services.AddDiscoveryClient(Configuration);

            services.AddDbContext<CatalogContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
               optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(CatalogContext).GetTypeInfo().Assembly.GetName().Name)));

            services.AddScoped<IProductDAO, ProductDAO>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseDiscoveryClient();
        }
    }
}
