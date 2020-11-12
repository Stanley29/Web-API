using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using web_api.Models;

namespace web_api
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
            // "DefaultConnection": "/Server=tcp:webapi-serhii.database.windows.net,1433;Initial Catalog=AWWCORdb;Persist Security Info=False;User ID=Serhii;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            //"DefaultConnection": "Server=webapi-serhii.database.windows.net;Database=AWWCORdb;User ID=Serhii;Password=Azure#128;Trusted_Connection=False;MultipleActiveResultSets=true;"
            //"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AWWCORdb;Trusted_Connection=True;"
            string con = Configuration.GetConnectionString("DefaultConnection");

            
            services.AddControllers();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddDbContext<ShoppingContext>(options => options.UseSqlServer(con));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
