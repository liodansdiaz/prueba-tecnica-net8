// See https://aka.ms/new-console-template for more information

using Confluent.Kafka;
using KafkaConsumer.Interfaces;
using KafkaConsumer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");



var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(( config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices(( services) =>
    {
        services.AddSingleton<IKafkaEventConsumer, KafkaEventConsumer>();
    })
    .Build();

var configuration = host.Services.GetRequiredService<IConfiguration>();
var kafkaSettings = configuration.GetSection("KafkaSettings");
var bootstrapServers = kafkaSettings["BootstrapServers"];
var topic = kafkaSettings["Topic"];
var groupId = kafkaSettings["GroupId"];


var kafkaEventConsumer = host.Services.GetRequiredService<IKafkaEventConsumer>();

kafkaEventConsumer.ConsumerEventAsync(groupId, bootstrapServers, topic);



