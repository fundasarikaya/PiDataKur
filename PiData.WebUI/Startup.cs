using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using PiData.Business.Abstract;
using PiData.Business.Concrete;
using PiData.DataAccess.Abstract;
using PiData.DataAccess.Concrete.EntityFramework;
using PiData.Entities;

namespace PiData.WebUI
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
            services.AddControllersWithViews();
            services.AddScoped<ICurrencyDal, EfCurrencyDal>();
            services.AddScoped<ICurrencyService, CurrencyManager>();
            services.AddScoped<IExchangeListService, ExchangeListManager>();
            services.AddScoped<ICurrencyListDal, EfCurrencyListDal>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<PiDataContext>(options =>
            options.UseSqlServer("Server=LAPTOP-7A1RLJDN\\CODERFUNDA;Database=PiData;user id=sa;password=dNA18_?;Trusted_Connection=True;MultipleActiveResultSets=true"));
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                  Path.Combine(env.ContentRootPath, "Content")),
                RequestPath = "/Content"
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Currency}/{action=Currency}/{id?}");
            });
        }
    }
}
