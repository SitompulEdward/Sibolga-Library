using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sibolga_Library.Data;
using Sibolga_Library.Models;
using Sibolga_Library.Repositories.AdminRepository;
using Sibolga_Library.Repositories.AkunRepository;
using Sibolga_Library.Repositories.BukuRepository;
using Sibolga_Library.Repositories.PeminjamanRepository;
using Sibolga_Library.Repositories.PengembalianRepository;
using Sibolga_Library.Services;
using Sibolga_Library.Services.AdminService;
using Sibolga_Library.Services.AkunService;
using Sibolga_Library.Services.BukuService;
using Sibolga_Library.Services.PeminjamanService;
using Sibolga_Library.Services.PengembalianService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library
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
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseMySQL(Configuration.GetConnectionString("mysql"));
            });

            services.AddAuthentication("CookieAuth").
                AddCookie("CookieAuth", option =>
                {
                    option.LoginPath = "/Akun/Login";
                    //option.AccessDeniedPath = "Akun/Dilarang";
                });

            services.AddScoped<IAkunRepository, AkunRepository>();
            services.AddScoped<IAkunService, AkunService>();

            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminService, AdminService>();

            services.AddScoped<IBukuRepository, BukuRepository>();
            services.AddScoped<IBukuService, BukuService>();

            services.AddScoped<IPeminjamanRepository, PeminjamanRepository>();
            services.AddScoped<IPeminjamanService, PeminjamanService>();

            services.AddScoped<IPengembalianRepository, PengembalianRepository>();
            services.AddScoped<IPengembalianService, PengembalianService>();

            services.AddTransient<FileService>();

            services.AddTransient<EmailService>();

            services.Configure<Email>(Configuration.GetSection("AturEmail"));

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                   name: "AreaAdmin",
                   areaName: "Admin",
                   pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                   name: "AreaPemasok",
                   areaName: "Pemasok",
                   pattern: "Pemasok/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                   name: "AreaUser",
                   areaName: "User",
                   pattern: "User/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Akun}/{action=Index}/{id?}");
            });
        }
    }
}
