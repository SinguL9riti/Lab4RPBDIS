﻿using Lab4RPBDIS.Data;

namespace Lab4RPBDIS.Middleware
{
    public class DbInitializerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public Task Invoke(HttpContext context, TransportDbContext dbContext)
        {
            if (!(context.Session.Keys.Contains("starting")))
            {
                DbInitializer.Initialize(dbContext);
                context.Session.SetString("starting", "Yes");
            }

            // Call the next delegate/middleware in the pipeline
            return _next.Invoke(context);
        }
    }
    public static class DbInitializerExtensions
    {
        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbInitializerMiddleware>();
        }

    }
}
