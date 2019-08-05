using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TOPMS.Data;
using TOPMS.Models;
using TOPMS.Services;
using TOPMS.Services.Contracts;

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

            //services.AddSingleton<IEmailSender, EmailSender>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    using (var context = serviceScope.ServiceProvider.GetRequiredService<TOPMSContext>())
                    {
                        AreaOfService[] areas = { new AreaOfService { Name = "Bulgaria" },
                        new AreaOfService { Name = "Europa" },
                        new AreaOfService { Name = "Asia" },
                        new AreaOfService { Name = "North America" },
                        new AreaOfService { Name = "South America" },
                        new AreaOfService { Name = "Africa" },
                        new AreaOfService { Name = "Australia" },
                        new AreaOfService { Name = "World" } };                  

                        foreach (var area in areas)
                        {
                            var areaExist = context.AreaOfService.FirstOrDefault(a => a.Name == area.Name);

                            if (areaExist == null)
                            {
                                context.AreaOfService.Add(area);
                            }
                        }

                        context.SaveChanges();
                    }
                }

                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    using (var context = serviceScope.ServiceProvider.GetRequiredService<TOPMSContext>())
                    {
                        Service[] services = { new Service { Name = "FCL" },
                        new Service { Name = "LCL" },
                        new Service { Name = "FTL" },
                        new Service { Name = "LTL" },
                        new Service { Name = "AirExpress" },
                        new Service { Name = "AirEconomy" },
                        new Service { Name = "AirCargo" },
                        new Service { Name = "Special" } };

                        foreach (var service in services)
                        {
                            var serviceExist = context.Services.FirstOrDefault(s => s.Name == service.Name);

                            if (serviceExist == null)
                            {
                                context.Services.Add(service);
                            }
                        }

                        context.SaveChanges();
                    }
                }

                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    using (var context = serviceScope.ServiceProvider.GetRequiredService<TOPMSContext>())
                    {
                        Status[] statuses = { new Status { Name = "Submited" },
                        new Status { Name = "Offered" },
                        new Status { Name = "Ordered" },
                        new Status { Name = "Confirmed" },
                        new Status { Name = "InTranzit" },
                        new Status { Name = "Delivered" },
                        new Status { Name = "Finished" },
                        new Status { Name = "Canceled" } };

                        foreach (var status in statuses)
                        {
                            var statusExist = context.Status.FirstOrDefault(s => s.Name == status.Name);

                            if (statusExist == null)
                            {
                                context.Status.Add(status);
                            }
                        }

                        context.SaveChanges();
                    }
                }

                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    using (var context = serviceScope.ServiceProvider.GetRequiredService<TOPMSContext>())
                    {
                        Transport[] transports = { new Transport { Name = "Sea" },
                        new Transport { Name = "Road" },
                        new Transport { Name = "Air" },
                        new Transport { Name = "All" } };

                        foreach (var transport in transports)
                        {
                            var transportExist = context.Transports.FirstOrDefault(t => t.Name == transport.Name);

                            if (transportExist == null)
                            {
                                context.Transports.Add(transport);
                            }
                        }

                        context.SaveChanges();
                    }
                }

                CreateRoles(serviceProvider).Wait();
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

        private async Task CreateRoles(IServiceProvider serviceProvider)
        { 
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            //var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            AppRole[] roles = { new AppRole { Name = "Admin", Descrition = "System Admin" },
                new AppRole { Name = "Approver", Descrition = "Inside company employee with certain authorization" },
                new AppRole { Name = "User", Descrition = "Inside company employee with certain authorization" },
                new AppRole { Name = "Forwarder", Descrition = "Outside company user - Forwarder" },
            };

            IdentityResult roleResult;

            foreach (var role in roles)
            {
                var roleExist = await RoleManager.RoleExistsAsync(role.Name);
                // ensure that the role does not exist
                if (!roleExist)
                {
                    //create the roles and seed them to the database: 
                    roleResult = await RoleManager.CreateAsync(role);
                }
            }

            //// find the user with the admin email 
            //var _user = await UserManager.FindByEmailAsync("admin@email.com");

            //// check if the user exists
            //if (_user == null)
            //{
            //    //Here you could create the super admin who will maintain the web app
            //    var poweruser = new ApplicationUser
            //    {
            //        UserName = "Admin",
            //        Email = "admin@email.com",
            //    };
            //    string adminPassword = "p@$$w0rd";

            //    var createPowerUser = await UserManager.CreateAsync(poweruser, adminPassword);
            //    if (createPowerUser.Succeeded)
            //    {
            //        //here we tie the new user to the role
            //        await UserManager.AddToRoleAsync(poweruser, "Admin");

            //    }
            //}
        }

        
    }
}
