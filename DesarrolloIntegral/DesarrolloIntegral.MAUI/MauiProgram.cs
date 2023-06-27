using DesarrolloIntegral.MAUI.Data;
using DesarrolloIntegral.Shared.Repositories;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace DesarrolloIntegral.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7009/") });
            builder.Services.AddScoped<IRepository, Repository>();

            return builder.Build();
        }
    }
}