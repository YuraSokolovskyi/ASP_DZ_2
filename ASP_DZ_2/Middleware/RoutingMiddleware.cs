namespace ASP_DZ_2.Middleware
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            string path = context.Request.Path.Value != null ? context.Request.Path.Value.ToLower() : "";

            switch (path)
            {
                case "/home":
                    await context.Response.WriteAsync("<h1>Домашня сторінка</h1>");
                    break;
                case "/mypicture":
                    await context.Response.WriteAsync("<h1>графічний файл</h1>");
                    break;
                case "/mycredential":
                    await context.Response.WriteAsync("<h1>JSON об’єкт із логіном та паролем користувача, переданим у запиті</h1>");
                    break;
                default:
                    context.Response.StatusCode = 404;
                    break;
            }
        }
    }
}
