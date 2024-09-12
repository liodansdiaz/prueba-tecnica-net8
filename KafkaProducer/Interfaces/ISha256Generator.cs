namespace KafkaProducer.Interfaces
{
    public interface ISha256Generator
    {
        string GenerateToSha256(string value);
    }
}
