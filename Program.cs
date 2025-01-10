using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testare_TravelingApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("ro"),
        new CultureInfo("fr")
    };

    options.DefaultRequestCulture = new RequestCulture("en"); // limba implicită
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    // Adăugăm CookieRequestCultureProvider pe prima poziție:
    options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider
    {
        CookieName = ".AspNetCore.Culture" // numele cookie-ului
    });
});

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

var supportedCultures = new[] { "en", "ro", "fr"};
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRequestLocalization();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
