using Microsoft.EntityFrameworkCore;
using WebDevProject.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Haal de connection string op uit de configuratie
var connectionString = builder.Configuration.GetConnectionString("MyDbContext");
// Voeg een DbContext-service toe aan de container met behulp van de conenction string
builder.Services.AddDbContext<MyDbContext>(x => x.UseSqlServer(connectionString));

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

app.Run();
