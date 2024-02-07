namespace ASP_DZ_2.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }

        public static IApplicationBuilder UseAuthentication(this IApplicationBuilder app, string login, string password)
        {
            return app.UseMiddleware<AuthenticationMiddleware>(login, password);
        }

        public static IApplicationBuilder UseCustomRouting(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RoutingMiddleware>();
        }
    }
}
