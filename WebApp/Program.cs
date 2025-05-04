using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));

builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
    {
        x.Password.RequiredLength = 8;
        x.User.RequireUniqueEmail = true;
        x.SignIn.RequireConfirmedEmail = false;


    })
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/signin";
    x.LogoutPath = "/signout";
    x.AccessDeniedPath = "/auth/denied";
    x.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    x.SlidingExpiration = true;
});

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
    app.UseHsts();
}
app.UseExceptionHandler("/Shared/Error");

app.UseStatusCodePages(async context  =>
{
    if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
    {
        context.HttpContext.Response.ContentType = "text/html";
        await context.HttpContext.Response.WriteAsync("<html><body><h1>Page not found.<br/> <a href=\"/\">Go Back</a></h1></body></html>");
    }
    if (context.HttpContext.Response.StatusCode == StatusCodes.Status500InternalServerError)
    {
        context.HttpContext.Response.ContentType = "text/html";
        await context.HttpContext.Response.WriteAsync("<html><body><h1>Something went wrong.<br/> <a href=\"/\">Go Back</a></h1></body></html>");
    }
});

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
