using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataConsumer.Models
{
    public class AppSettings
    {
        public RabbitMQSettings RabbitMQSettings { get; set; }
    }

    public class RabbitMQSettings
    {
        public string AmqpUri { get; set; }
        public string UserQueueName { get; set; }
    }
}
