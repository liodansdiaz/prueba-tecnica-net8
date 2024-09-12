using Confluent.Kafka;
using KafkaProducer.Interfaces;

namespace KafkaProducer.Services
{
    public class KafkaEventProducer : IKafkaEventProducer
    {

        public async Task ProduceMessage(string topic, string value, string bootstrapServers)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers
            };

            IProducer<Null, string> producer = new ProducerBuilder<Null, string>(config).Build();

            var message = new Message<Null, string> { Value = value};
            var response = await producer.ProduceAsync(topic, message);
            Console.WriteLine($"Mensaje enviado: {value} a la particion {response.Partition}");
        }
    }
}
