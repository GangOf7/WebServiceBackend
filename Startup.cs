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
using PiratesBay.Data;
using PiratesBay.Data.IRepositories;
using PiratesBay.Data.Repositories;
using PiratesBay.Services.Communication;


namespace PiratesBay
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
            services.AddControllers();

            //********************* SQL Lite Connection *******************************************

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(Configuration.GetConnectionString("SQLite"));
            });

            //********************* SQL Server Connection *******************************************

            //services.AddDbContext<DataContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            //********************************-------------*****************************************

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.Configure<TwilioSettings>(Configuration.GetSection("Twilio"));
            services.AddScoped<Communicate>();
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
