using Microsoft.EntityFrameworkCore;
using War.Data;
using Microsoft.AspNetCore.Identity;
using War.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WarDBContextConnection") ?? throw new InvalidOperationException("Connection string 'WarDBContextConnection' not found.");

builder.Services.AddDbContext<WarDBContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<WarUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<WarDBContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Player/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Player}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
