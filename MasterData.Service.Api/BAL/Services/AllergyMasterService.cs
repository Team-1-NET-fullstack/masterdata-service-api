using MasterData.Service.Api.DAL;
using MasterData.Service.Api.Entities;
using MasterData.Service.Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MasterData.Service.Api.BAL.Services
{
    public class AllergyMasterService
    {
        private readonly IMongoCollection<AllergyMasters> _allergyMasters;
        private string _amqpUri;
        private string _queueName;
        private readonly AppSettings _appSettings;

        private readonly ILogger<AllergyMasters> _logger;

        public AllergyMasterService(ICTGeneralHospitalDatabaseSettings settings, IOptions<AppSettings> appSettings, ILogger<AllergyMasters> logger)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _allergyMasters = database.GetCollection<AllergyMasters>(settings.AllergyCollection);
            _appSettings = appSettings.Value;
            _amqpUri = _appSettings.RabbitMQSettings.AmqpUri;
            _queueName = _appSettings.RabbitMQSettings.UserQueueName;



        }

        public async Task PublishMessage(AllergyMasters allergyMaster)
        {
            await Task.Run(() =>
            {
                Publish(allergyMaster);
            });
        }

        public void Publish(AllergyMasters allergyMaster)
        {
            _logger.LogInformation("publish message : ");
            var factory = new ConnectionFactory
            {
                Uri = new Uri(_amqpUri)
            };
            //_amqpUri 
            _logger.LogInformation("_amqpUri : " + _amqpUri);
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            //QueueDeclaration
            _logger.LogInformation("QueueDeclaration");
            channel.QueueDeclare(_queueName,
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);
            //jsonString Declaration
            _logger.LogInformation("jsonString Declaration");
            string jsonString = JsonSerializer.Serialize(allergyMaster);
            //jsonString 
            _logger.LogInformation("jsonString : " + jsonString);
            var body = Encoding.UTF8.GetBytes(jsonString);
            channel.BasicPublish("", _queueName, null, body);
        }


        public List<AllergyMasters> GetAllAllergy()
        {
            List<AllergyMasters> allergyMasters;
            allergyMasters = _allergyMasters.Find(allergy => true).ToList();
            return allergyMasters;
        }
        public AllergyMasters GetAllergyById(string id) =>
            _allergyMasters.Find<AllergyMasters>(allergy => allergy.Id == id).FirstOrDefault();

        public AllergyMasters GetAllergyByDescription(string desc)
        {
            try
            {
                return _allergyMasters.Find<AllergyMasters>(allergy => allergy.Description.ToLower() == desc.ToLower()).First();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<AllergyMasters> CreateAllergy(AllergyMasters allergyMaster)
        {

            await _allergyMasters.InsertOneAsync(allergyMaster);

            //TodoItemMessage todoItemMessage = new TodoItemMessage()  --
            //{
            //    toDoItem = todoItem, --allergyMaster
            //    Command = "add_todoitem" --Command
            //};

            //await _ToDoMessagePublisher.PublishMessage(todoItemMessage);

            AllergyMasterMessage allergyMasterMessage = new AllergyMasterMessage()
            {
                allergyMasters = allergyMaster,
                Command = "createAllergy"
            };
            await PublishMessage(allergyMaster);

            return allergyMaster;

        }
        public async Task<bool> UpdateAsync(AllergyMasters allergyMastersIn)
        {
            var updateResult = await _allergyMasters.ReplaceOneAsync(filter: g => g.Id == allergyMastersIn.Id, replacement: allergyMastersIn);


            return updateResult.IsAcknowledged
                                && updateResult.ModifiedCount > 0;
        }
    }

}



