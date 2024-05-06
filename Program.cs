using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shop_mvc.Models;
var builder = WebApplication.CreateBuilder(args);
var con =
    """"
    Data Source=.\SQLEXPRESS;
    Initial Catalog=shop_mvc;
    Integrated Security=True;
    Encrypt=True;
    Trust Server Certificate=True
    """";

builder.Services.AddDbContext<context>(options => options.UseSqlServer(con));

builder.Services.AddDefaultIdentity<iuser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(e=>e.MapRazorPages());
app.Run();
