using ASP_DZ_2.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string login = "login";
string password = "1234";

app.UseErrorHandling();

app.UseAuthentication(login, password);

app.UseCustomRouting();

app.Run();
