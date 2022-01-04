var builder = WebApplication.CreateBuilder(args);

string port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
string url = String.Concat("http://0.0.0.0:", port);
builder.WebHost.UseUrls(url);

Console.WriteLine(port);
builder.Services.AddControllersWithViews();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

