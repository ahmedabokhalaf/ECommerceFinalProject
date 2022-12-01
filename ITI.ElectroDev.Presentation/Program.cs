using ITI.ElectroDev.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<Context>(options =>
{
    options.UseLazyLoadingProxies()
        .UseSqlServer(builder.Configuration.GetConnectionString("connectionKey")); ;
});
builder.Services.AddIdentity<User, IdentityRole>
   ().AddEntityFrameworkStores<Context>();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions()
{
    RequestPath = "/Content",
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
