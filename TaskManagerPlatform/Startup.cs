using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.EmailNotification;
using TaskManagerPlatform.Application.Issues;
using TaskManagerPlatform.Application.MailSender;
using TaskManagerPlatform.Application.Organizations;
using TaskManagerPlatform.Application.UserManager;
using TaskManagerPlatform.Application.Users;
using TaskManagerPlatform.Domain.Repository;
using TaskManagerPlatform.Domain.Repository.UserManager;
using TaskManagerPlatform.EntityFrameworkCore;
using TaskManagerPlatform.EntityFrameworkCore.Repository.Issues;
using TaskManagerPlatform.EntityFrameworkCore.Repository.Organizations;
using TaskManagerPlatform.EntityFrameworkCore.Repository.UserManager;
using TaskManagerPlatform.EntityFrameworkCore.Repository.Users;

namespace TaskManagerPlatform
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
            services.AddDbContext<TaskManagerDbContext>();
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserManagerRepository, UserManagerRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<IEmailSender, MessageSender>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
