using KafkaProducer.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace KafkaProducer.Services
{
    public class Sha256Generator : ISha256Generator
    {
        public string GenerateToSha256(string value)
        {
            using var sha256 = SHA256.Create();
            var arrayBytes = Encoding.UTF8.GetBytes(value);
            var bytes = sha256.ComputeHash(arrayBytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
