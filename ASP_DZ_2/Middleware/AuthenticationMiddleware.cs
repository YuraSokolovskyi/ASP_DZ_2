namespace ASP_DZ_2.Middleware
{
    public class AuthenticationMiddleware
    {
        private RequestDelegate _next;
        private string _login;
        private string _password;

        public AuthenticationMiddleware(RequestDelegate next, string login, string password)
        {
            _next = next;
            _login = login;
            _password = password;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var login = context.Request.Query["login"];
            var password = context.Request.Query["password"];

            Console.WriteLine(login + " " + password);

            if (string.IsNullOrWhiteSpace(login) || 
                string.IsNullOrWhiteSpace(password) || 
                login != _login || 
                ReverseString(password) != _password)
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await _next.Invoke(context);
            }
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
