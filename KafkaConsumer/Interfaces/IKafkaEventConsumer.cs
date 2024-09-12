using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer.Interfaces
{
    public interface IKafkaEventConsumer
    {
        void ConsumerEventAsync(string groupId, string bootstrapServers, string topic);
    }
}
