using MasterData.Service.Api.BAL.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MasterDataConsumer.Models
{
    public class Worker: BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly AppSettings _appSettings;

        private readonly string amqpUri;
        private readonly string userQueueName;

        private readonly AllergyMasterService _allergyMasterService;

        public Worker(ILogger<Worker> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));

            amqpUri = _appSettings.RabbitMQSettings.AmqpUri;
            userQueueName = _appSettings.RabbitMQSettings.UserQueueName;

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(() =>
            {
                ConsumeMessage(stoppingToken);
            });
        }

        private void ConsumeMessage(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            _logger.LogInformation("listeneing on " + amqpUri);
            _logger.LogInformation("QueueName " + userQueueName);

            var factory = new ConnectionFactory
            {
                Uri = new Uri(amqpUri)
            };
            //var factory = new ConnectionFactory() { HostName = "localhost:15672" };
            var connection = factory.CreateConnection();

            _logger.LogInformation("Connection established to " + amqpUri);

            var channel = connection.CreateModel();

            _logger.LogInformation("channel created...");

            channel.QueueDeclare(userQueueName,
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            _logger.LogInformation("Queue declared...");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += MessageHandler;

            _logger.LogInformation("Message handler attached as an event...");

            channel.BasicConsume(userQueueName, true, consumer);

        }

        private void MessageHandler(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            _logger.LogInformation("Received Body : " + message);

            if (message.ToLower() == "stop")
            {
                _logger.LogInformation("STOP message received.....");
                _logger.LogInformation("STOP command triggering.....");
                //stopProcess = true;
            }
            else
            {
                var toDoItemMessage = JsonSerializer.Deserialize<AllergyMasterMessage>(body);

                AllergyMasterMessage allergyMasterMessage = null;
                if (allergyMasterMessage == null)
                {
                    return;
                }
                if (allergyMasterMessage.allergyMasters != null)
                {
                    allergyMasters = allergyMasterMessage;
                }

                var command = toDoItemMessage.Command.ToLower();

                switch (command)
                {
                    case "createAllergy":
                        {
                            //_dataRepository.AddToDoItem(toDoItem);
                             _allergyMasterService.CreateAllergy(allergyMasters);
                            break;
                        }

                    case "updateAllergy":
                        {
                            //_dataRepository.UpdateToDoItem(toDoItemId, toDoItem);
                            break;
                        }


                }
            }
    }
}
