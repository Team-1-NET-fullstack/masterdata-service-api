using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.Models
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
