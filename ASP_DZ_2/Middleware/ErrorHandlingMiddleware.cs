﻿namespace ASP_DZ_2.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Response.StatusCode > 200)
            {
                context.Response.ContentType = "text/html; charset=utf-8";
            }

            switch (context.Response.StatusCode)
            {
                case 403:
                    await context.Response.WriteAsync("<h2>Помилка аутентифікації</h2>");
                    break;

                case 404:
                    await context.Response.WriteAsync("<h2>Цей ресурс не знайдено</h2>");
                    break;

                default:
                    break;
            }
        }
    }
}
