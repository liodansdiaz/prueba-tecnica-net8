using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafkaConsumer.Interfaces;

namespace KafkaConsumer.Services
{
    public class KafkaEventConsumer : IKafkaEventConsumer
    {

        public void ConsumerEventAsync(string groupId, string bootstrapServers, string topic)
        {
            
            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Null, string>(config).Build();

            consumer.Subscribe(topic);

            try
            {
                while (true)
                {
                    var response = consumer.Consume(CancellationToken.None);
                    Console.WriteLine($"Consumed message '{response.Message.Timestamp.UtcDateTime}'");

       
                    if (response.Message == null)
                    {
                        Console.WriteLine($"Consumed message '{response.Message.Value}'");
                    }


                }
            }
            catch (ConsumeException e)
            {
                Console.WriteLine($"Error occurred: {e.Error.Reason}");
            }
        }
    }
}
