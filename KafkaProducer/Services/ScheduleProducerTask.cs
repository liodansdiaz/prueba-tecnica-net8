using KafkaProducer.Interfaces;

namespace KafkaProducer.Services
{
    public class ScheduleProducerTask : IScheduleProducerTask
    {
        private readonly IKafkaEventProducer _producer;
        private readonly ISha256Generator _sha256Generator;

        public ScheduleProducerTask(IKafkaEventProducer producer, ISha256Generator sha256Generator)
        {
            _producer = producer;
            _sha256Generator = sha256Generator;
        }
        public async Task Execute( string topic, string bootstrapServers)
        {

            while (true)
            {
                var currentTime = DateTime.UtcNow.ToString("o");
                Console.WriteLine($"Hora del Sistema: {currentTime}");
                var sha256 = _sha256Generator.GenerateToSha256(currentTime);

                await _producer.ProduceMessage(topic, sha256, bootstrapServers);
                await Task.Delay(1000);
            }
        }

    }
}
