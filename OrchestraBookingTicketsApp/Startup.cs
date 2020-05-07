using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrchestraBookingTicketsApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrchestraBookingTicketsApp.DataAccess;
using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.Repositories;
using OrchestraBookingTicketsApp.Services;
using OrchestraBookingTicketsApp.Areas.Identity.Services;

namespace OrchestraBookingTicketsApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            var connection = @"Server=(localdb)\mssqllocaldb;Database=TestEntityFrameworkDb;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<OrchestraContext>(options =>
                options.UseSqlServer(connection));

            //services.AddDbContext<OrchestraContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<OrchestraContext>();
            //
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<OrchestraContext>(
              options =>
              options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection"))
               );


            //Adding the identity role
            services.AddIdentity<IdentityUser, IdentityRole>()
             .AddRoleManager<RoleManager<IdentityRole>>()
             .AddDefaultUI()
             .AddDefaultTokenProviders()
             .AddEntityFrameworkStores<ApplicationDbContext>();

            // add constraints
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
            });

            //add repo
            services.AddScoped<IOrchestraRepository, OrchestraRepository>();
            services.AddScoped<IOrchestraHistoryRepository, OrchestraHistoryRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            //add services
            services.AddScoped<OrchestraService>();
            services.AddScoped<OrchestraHistoryService>();
            services.AddScoped<LocationService>();
            services.AddScoped<UserService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
