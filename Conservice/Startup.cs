using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conservice.Data;
using Conservice.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 
namespace Conservice
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
            string connString = null;
            connString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ConserviceContext>(options => options
            .UseSqlServer(connString)
            .UseLazyLoadingProxies()
            );
            // Inject my services
            
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IReportingService, ReportingService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();


            //services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            //{
            //    var libraryPath = Path.GetFullPath(
            //        Path.Combine(HostEnvironment.ContentRootPath, "..", "MyClassLib"));
            //    options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
            //});
            //   .AddRazorPagesOptions();
            //  services.AddMvc().AddRazorRuntimeCompilation();

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
              //  app.UseExceptionHandler("/Home/Error");
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
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
