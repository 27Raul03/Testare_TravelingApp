using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testare_TravelingApp.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Testare_TravelingAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Testare_TravelingAppContext")
    ?? throw new InvalidOperationException("Connection string 'Testare_TravelingAppContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Testare_TravelingAppContext")
    ?? throw new InvalidOperationException("Connection string 'Testare_TravelingAppContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
