using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PCI_Website_2018.Models;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Extensions.Logging;

namespace PCI_Website_2018
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<FirmContext>(options =>
                  options.UseSqlite("Data Source=PCI_Website_2018.db"));
            services.AddDbContext<UploadContext>(options =>
                  options.UseSqlite("Data Source=PCI_Website_2018.db"));
            services.AddDbContext<TransactionsContext>(options =>
                    options.UseSqlServer(@"Server=SQL;Database=Palmernet;uid=pciweb321;pwd=web1pci1;"));      
            services.AddDbContext<ClientsContext>(options =>
                    options.UseSqlServer(@"Server=SQL;Database=Palmernet;uid=pciweb321;pwd=web1pci1;"));
            services.AddDbContext<ClientsReferencesContext>(options =>
                    options.UseSqlServer(@"Server=SQL;Database=Palmernet;uid=pciweb321;pwd=web1pci1;")); 
            // services.AddDbContext<TransactionsContext>(options =>
            //         options.UseSqlServer(ConfigurationManager.ConnectionStrings[@"PCIDatabase"].ConnectionString));      
            // services.AddDbContext<ClientsContext>(options =>
            //         options.UseSqlServer(ConfigurationManager.ConnectionStrings[@"PCIDatabase"].ConnectionString));                          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                // if want to use asp-area helpers ...
                // routes.MapRoute(name: "areaRoute",
                //     template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
