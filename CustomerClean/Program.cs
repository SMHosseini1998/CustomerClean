using CustomerClean.Application.Common.Settings;
using CustomerClean.Application.Common.StaticStrings;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var appSettingsFileName = builder.Environment.IsDevelopment()
    ? FileNames.AppSettingsDevelopmentName
    : FileNames.AppSettingsName;

var configuration = builder
    .Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(appSettingsFileName)
    .Build();

builder.Services.AddControllersWithViews();
builder.Services.AddApplication(configuration);

builder.Services.AddRazorPages().AddRazorRuntimeCompilation().AddJsonOptions(
            options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
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
