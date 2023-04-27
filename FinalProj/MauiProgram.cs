﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using FinalProj.Data;
using FinalProj.Data.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProj;

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
		builder.Services.AddSingleton<DataAccessLayer>();

		builder.Services.AddSingleton<CustomerManagement>();

		builder.Services.AddSingleton<StockQuery>();
		builder.Services.AddSingleton<WorkBooking>();
		builder.Services.AddSingleton<WorkScheduling>();
		builder.Services.AddSingleton<UniqueIntGenerator>();

		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		#endif
		
		//builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
