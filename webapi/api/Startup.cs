using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using api.Middleware;
using api.Model;
using api.Servcies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

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
            services.AddDbContext<AppDb>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<TodosService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                Console.WriteLine("My process used working set {0:n3} MB of working set and CPU {1:n} msec", mem / (1024.0 * 1000) , cpu.TotalMilliseconds);
                Console.WriteLine("--------------------------------");

//                foreach (var aProc in Process.GetProcesses().ToList().Where(x=>x.ProcessName == "dotnet"))
//                    Console.WriteLine("Proc {0,30}  CPU {1,-20:n} msec", aProc.ProcessName, cpu.TotalMilliseconds, cpu.m);
            });
            

            app.UseMvc();
        }
    }
}
