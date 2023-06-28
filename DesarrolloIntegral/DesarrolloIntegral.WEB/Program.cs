using CurrieTechnologies.Razor.SweetAlert2;
using DesarrolloIntegral.Shared.Repositories;
using DesarrolloIntegral.WEB;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7009/") });
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();


await builder.Build().RunAsync();
