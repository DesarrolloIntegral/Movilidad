using DesarrolloIntegral.Shared.Repositories;
using DesarrolloIntegral.WEB;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7009/") });
builder.Services.AddScoped<IRepository, Repository>();

await builder.Build().RunAsync();
