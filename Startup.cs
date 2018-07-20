﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using StockAnalysis.Services;
using StockAnalysis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace StockAnalysis
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(options =>
            {
                _configuration.Bind("AzureAd", options);
            })
            .AddCookie();


            services.AddSingleton<ICurrentMutualFund, CurrentMutualFund>();
            services.AddDbContext<StockAnalysisDbContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("StockAnalysis")));
            //services.AddScoped<IStocksymbolData, SqlStocksymbolData>();
            services.AddScoped<IStocksymbolData, InMemoryStocksymbolData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              ICurrentMutualFund currentMutualFund, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {               
                app.UseDeveloperExceptionPage();
            }

            app.UseRewriter(new RewriteOptions()
                                .AddRedirectToHttpsPermanent());

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(ConfigureRoutes);
          
            app.Run(async (context) =>
            {
                var greeting = currentMutualFund.GetTopStockCategoryInMF();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index/2

            routeBuilder.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
