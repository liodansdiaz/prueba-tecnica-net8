namespace KafkaProducer.Interfaces
{
    public interface IScheduleProducerTask
    {
        Task Execute(string topic, string bootstrapServers);
       
    }
}
