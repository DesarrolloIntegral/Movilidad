using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using DesarrolloIntegral.Shared.Repositories;
using DesarrolloIntegral.WEBServer.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7009/") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://pruebas4.ddns.net/") });
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();

builder.Services.AddRouting();

builder.Services.AddBlazoredModal(); //31102023 para prueba de este framework

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
