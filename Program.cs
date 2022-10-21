using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models.Repository;
using webapp_travel_agency.Models.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPackageRepo, PackageRepository>();
builder.Services.AddScoped<IDestinationRepo, DestinationRepository>();
builder.Services.AddScoped<IMessageRepo, MessageRepository>();

builder.Services.AddScoped<TravelAgencyContext>();

var connectionString = builder.Configuration.GetConnectionString("TravelAgencyContextConnection") ?? throw new InvalidOperationException("Connection string 'TravelAgencyContextConnection' not found.");

builder.Services.AddDbContext<TravelAgencyContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TravelAgencyContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
