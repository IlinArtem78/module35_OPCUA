using AutoMapper;
using Kafka_API;
using Kafka_API.Repositories;
using Kafka_web;

using OPCUA_API.Repositoria;
using OPCUA_API;
using System.Diagnostics;

using OPCUA_API.WorkWithServer;

class Program
{ 
    public static async Task Main(string[] args) { 
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<WorkWithKafka>();
            builder.Services.AddScoped<IKafkaAction, KafkaRepositoria>();
           
            builder.Services.AddScoped<IWorkerOPCUA, OPCUARepositories>();
            builder.Services.AddSingleton<IRunOpcUA, RunOPCUA>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
      
        app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Registration}/{id?}");
        app.Run();
        /*
        // Получаем экземпляр службы и вызываем метод для запуска оконного приложения
        using var scope = app.Services.CreateScope();
        var windowsAppService = scope.ServiceProvider.GetRequiredService<RunOPCUA>();
        await windowsAppService.StartWindowsFormsApp();
        // Запуск приложения
        await app.RunAsync();

        // При остановке приложения
        using var scopeForCleanup = app.Services.CreateScope();
        var cleanupService = scopeForCleanup.ServiceProvider.GetRequiredService<RunOPCUA>();
        cleanupService.StopWindowsFormsApp();
        */



    }

}

/*
{       //maping 
    var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        })
        .Build();
}
*/