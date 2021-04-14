using IntexFinalMummy.Data;
using IntexFinalMummy.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexFinalMummy
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
            //NOTE TO TA: IF YOU TRY TO DEBUG FROM THE FILE IT WILL NOT WORK BECAUSE OF SECRETS MANAGMENT
            //We have put the connection string on AWS if you need the connection string feel free to reach out
            //Teams
            string endpointAuth = Environment.GetEnvironmentVariable("endpointAuth1");
            string endpointMain = Environment.GetEnvironmentVariable("endpointMain1");

            //bRING IN THE dBS
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection") + endpointAuth));
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddDefaultUI()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<IntexMummyVaultContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("MummyConnection") + endpointMain));
            //dEFINE SPECIAL USER POLICIES
            services.AddAuthorization(options => {
                options.AddPolicy("User/Admin",
                    builder => builder.RequireRole("Admin", "User"));
                options.AddPolicy("ReadOnly",
                    builder => builder.RequireRole("Admin", "User","Unassigned"));
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            //Endpoint magic
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "PageNum",
                    "ViewRecords/{PageNum}",
                    new { Controller = "Home", action = "ViewRecords" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            
        }
    }
}
