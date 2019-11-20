
using System;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace api.Middleware
{
    public static class ErrorHandlerMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Trace.WriteLine($"Something went wrong: {contextFeature.Error}");
                        
                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(new {
                                            StatusCode = (int)context.Response.StatusCode,
                                            Message =  contextFeature.Error.Message
                                        })
                            );
                    }
                });
            });
        }
    }
}
