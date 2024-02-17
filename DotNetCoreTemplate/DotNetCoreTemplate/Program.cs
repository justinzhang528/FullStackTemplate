using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Config;
using NLog.Web;
using DotNetCore.Filters;
using DotNetCore.Models.Settings;
using DotNetCore.Repositories;
using DotNetCore.Repositories.Interfaces;
using DotNetCore.Service;
using DotNetCore.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    // options.Filters.Add(typeof(LogFilter));
}).AddNewtonsoftJson();

builder.Services.AddHangfire(x => x.UseMemoryStorage(new MemoryStorageOptions()));
builder.Services.AddHangfireServer(options => options.SchedulePollingInterval = TimeSpan.FromSeconds(1));

builder.Services.Configure<AppsettingsModel>(builder.Configuration);
builder.Services.Configure<StoredProceduresSettings>(builder.Configuration.GetSection("StoredProceduresSettings"));

#region Wrapper

builder.Services.TryAddSingleton<ILoggerWrapper, LoggerWrapper>();
builder.Services.TryAddSingleton<IAdminService, AdminService>();
builder.Services.TryAddSingleton<IAdminRepository, AdminRepository>();


#endregion

builder.Services.TryAddSingleton<ILoggerService, LoggerService>();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<IHttpClientService, HttpClientService>().SetHandlerLifetime(TimeSpan.FromSeconds(5));
builder.Services.TryAddSingleton<TaskExceptionFilter>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TaskManager API",
        Version = "v1",
        Description = "TaskManager API Document"
    });
});
builder.Services.AddSwaggerGenNewtonsoftSupport();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var nlogFile = "nlog.config";
LogManager.Configuration = new XmlLoggingConfiguration(nlogFile);
builder.Host.UseNLog();


var app = builder.Build();
app.UseCors("AllowAll");



app.MapGet("/", () => "Hello World!");

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();