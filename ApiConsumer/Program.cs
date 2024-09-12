// See https://aka.ms/new-console-template for more information

using ApiConsumer.Interfaces;
using ApiConsumer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices( (services) =>
    {
        services.AddHttpClient<IHttpApiConsumer, HttpApiConsumer>();
    })
    .Build();


var configuration = host.Services.GetRequiredService<IConfiguration>();

var apiConsumerSettings = configuration.GetSection("ApiSettings");
var baseUrl = apiConsumerSettings.GetValue<string>("BaseUrl");
var apiKey = apiConsumerSettings.GetValue<string>("ApiKey");

var apiCall = host.Services.GetRequiredService<IHttpApiConsumer>();

string? endPoint;
string url, option;

do
{
    Console.WriteLine("Selecciona una opción:");
    Console.WriteLine("1. Endpoint: /v2/schedule");
    Console.WriteLine("2. Endpoint: /v2/schedule_expanded");
    Console.WriteLine("3. Salir");

    option = Console.ReadLine();
    switch (option)
    {
        case "1":
            endPoint = apiConsumerSettings.GetValue<string>("EndPoint1"); 
            url = $"{baseUrl}{endPoint}?token={apiKey}";
            await apiCall.ConsumeAsync(url);
            break;

        case "2":
            endPoint = apiConsumerSettings.GetValue<string>("EndPoint2"); 
            url = $"{baseUrl}{endPoint}?token={apiKey}";
            await apiCall.ConsumeAsync(url);
            break;

        case "3":
            Console.WriteLine("Saliendo...");
            return;

        default:
            Console.WriteLine("Opción no válida, intenta de nuevo.");
            break;
    }
} while (option != "3");


    

        

