using CP.Abstractions.Models;
using CP.Api.Web.ActionFilters;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = builder.Configuration.Get<AppSettings>() ?? new AppSettings();

builder.Services
    .AddDependencies(settings)
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });

builder.Host.UseSerilog();

builder.Services.AddSwaggerConfig(settings);
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

Serilog.Log.Logger = new Serilog.LoggerConfiguration()
    .ReadFrom.Configuration(app.Configuration)
    .CreateLogger();

try
{
    Log.Information("web api Application starting up");

    if (settings.Settings.InTestMode)
    {
        app.UseDeveloperExceptionPage();
    }

    // Configure the HTTP request pipeline.
    app.UseSwaggerCustomConfig(settings);

    app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();

    app.UseAuthorization();

    app.MapControllers();
    CustomExceptionHandler.AppSettings = settings;
    app.UseExceptionHandler(CustomExceptionHandler.HandleException);

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application terminated unexpectedly");
    throw;
}
finally
{
    Log.CloseAndFlush();
}
