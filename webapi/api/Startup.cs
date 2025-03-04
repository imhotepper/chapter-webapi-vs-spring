﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using api.jobs;
using api.Middleware;
using api.Model;
using api.Servcies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.OpenApi.Models;


namespace api
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
            services.AddHostedService<SimpleJob>();

            var conStr = Configuration.GetConnectionString("DefaultConnection");
            var pgConn = Environment.GetEnvironmentVariable("DATABASE_URL");

Console.WriteLine("ENV pgConn: " + pgConn);

            if (!string.IsNullOrWhiteSpace(pgConn))
                conStr = HerokuPGParser.ConnectionHelper.BuildExpectedConnectionString(pgConn);

          if (string.IsNullOrWhiteSpace(conStr) && !string.IsNullOrWhiteSpace(pgConn))
            conStr = pgConn;
            
Console.WriteLine("ENV connStr: " + conStr);

            services.AddDbContext<AppDb>(options =>options.UseNpgsql(conStr));

            services.AddScoped<TodosService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todos API", Version = "v1" });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.ConfigureExceptionHandler();

            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
                var proc = Process.GetCurrentProcess();
                var mem = proc.WorkingSet64;
                var cpu = proc.TotalProcessorTime;
                Console.WriteLine("--------------------------------");
                Console.WriteLine("My process used working set {0:n3} MB of working set and CPU {1:n} msec", mem / (1024.0 * 1000), cpu.TotalMilliseconds);
                Console.WriteLine("--------------------------------");
            });


            app.UseMvc();

            // update database schema
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (serviceScope.ServiceProvider.GetService<AppDb>() == null) return;
                var ctx = serviceScope.ServiceProvider.GetService<AppDb>();
                new DatabaseFacade(ctx).Migrate();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todos API V1");
                c.RoutePrefix = string.Empty;

            });

        }
    }
}
