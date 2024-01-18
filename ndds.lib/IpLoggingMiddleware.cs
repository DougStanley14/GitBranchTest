using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Context;

namespace ndds.lib
{
    public class IpLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public IpLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var ipAddress = $"From: {context.Connection.RemoteIpAddress?.ToString()}";
            using (LogContext.PushProperty("IPAddress", ipAddress))
            {
                await _next(context);
            }
        }
    }
}
