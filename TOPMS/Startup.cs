using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TOPMS.Data;
using TOPMS.Models;
using TOPMS.Services;
using TOPMS.Services.Common;
using TOPMS.Services.Contracts;
using CompanyService = TOPMS.Services.CompanyService;

namespace TOPMS
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<TOPMSContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TOPMSContext")));

            services.AddIdentity<AppUser, AppRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<TOPMSContext>()
                .AddDefaultTokenProviders();

            // Register Application Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAreaOfServiceService, AreaOfServiceService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICompanyServiceService, CompanyServiceService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<ITransportService, TransportService>();
            services.AddTransient<ICompanyTransportService, CompanyTransportService>();
            services.AddTransient<ICompanyAreaOfServiceService, CompanyAreaOfServiceService>();
            services.AddTransient<ITransportRFQService, TransportRFQService>();
            services.AddTransient<ISeedService, SeedService>();

            //services.AddSingleton<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, ISeedService seedService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                seedService.SeedAreas(GlobalConstants.AreasString);
                seedService.SeedServices(GlobalConstants.ServicesString);
                seedService.SeedStatuses(GlobalConstants.StatusesString);
                seedService.SeedTransports(GlobalConstants.TransportsString);
                seedService.SeedRoles(GlobalConstants.UserRolesString);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
