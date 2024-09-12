// See https://aka.ms/new-console-template for more information


using KafkaProducer.Interfaces;
using KafkaProducer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(( config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices(( services) =>
    {
        services.AddSingleton<IKafkaEventProducer, KafkaEventProducer>();
        services.AddSingleton<IScheduleProducerTask, ScheduleProducerTask>();
        services.AddSingleton<ISha256Generator, Sha256Generator>();
    })
    .Build();




var configuration = host.Services.GetRequiredService<IConfiguration>();

var kafkaSettings = configuration.GetSection("KafkaSettings");
var bootstrapServers = kafkaSettings["BootstrapServers"];
var topic = kafkaSettings["Topic"];


var sheduleProducerTask = host.Services.GetRequiredService<IScheduleProducerTask>();
await sheduleProducerTask.Execute(topic, bootstrapServers);

