namespace KafkaProducer.Interfaces
{
    public interface IKafkaEventProducer
    {
        Task ProduceMessage(string topic, string value, string bootstrapServers);
    }
}
