using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecruitmentApp.Models.database;

namespace RecruitmentApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds identity database connection to services
            // services.AddDbContext<AppIdentityDBContext>(options => options.UseSqlServer(Configuration["Data:RecruitmentIdentity:ConnectionString"]));
            // Adds content database connection to services
            services.AddDbContext<RecruitmentDBContext>(options => options.UseSqlServer(Configuration["Data:Recruitment:ConnectionString"]));

            // Setting lifetime of database table access
            services.AddTransient<IOrganizationDatabase, EFOrganizationDatabase>();
            services.AddTransient<ICategoryDatabase, EFCategoryDatabase>();
            services.AddTransient<IJobDatabase, EFJobDatabase>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
