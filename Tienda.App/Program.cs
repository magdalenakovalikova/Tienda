using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Tienda.App;
using Tienda.App.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<ProductService>();
// Load configuration
var baseAddress = builder.Configuration["ApiBaseAddress"] ?? "https://localhost:7140/";
//
//var builder = WebApplication.CreateBuilder(args);

//// Option 1: Using Configuration
//var apiBaseAddress1 = builder.Configuration["ApiBaseAddress"];

//// Option 2: Using GetSection
//var apiBaseAddressSection = builder.Configuration.GetSection("ApiBaseAddress").Value;

//var app = builder.Build();

//app.MapGet("/", () => $"API Base Address: {apiBaseAddress1}");

//app.Run();

//

// Use the base address defined in launchSettings.json
var apiBaseAddress = builder.Configuration.GetValue<string>("ApiBaseAddress") ?? throw new InvalidOperationException("ApiBaseAddress is not configured.");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

await builder.Build().RunAsync();
