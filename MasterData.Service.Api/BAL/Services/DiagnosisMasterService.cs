using MasterData.Service.Api.DAL;
using MasterData.Service.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.BAL.Services
{
    public class DiagnosisMasterService
    {
        private readonly IMongoCollection<DiagnosisMasters> _diagnosisMasters;

        public DiagnosisMasterService(ICTGeneralHospitalDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);


            _diagnosisMasters = database.GetCollection<DiagnosisMasters>(settings.DiagnosisCollection);
        }
        public List<DiagnosisMasters> GetAllDiagnosis()
        {
            List<DiagnosisMasters> diagnosisMasters;
            diagnosisMasters = _diagnosisMasters.Find(diagnosis => true).ToList();
            return diagnosisMasters;
        }
        public DiagnosisMasters GetDiagnosisById(string id) =>
            _diagnosisMasters.Find<DiagnosisMasters>(diagnosis => diagnosis.Id == id).FirstOrDefault();
        public DiagnosisMasters GetDiagnosisByDescription(string desc) =>
            _diagnosisMasters.Find<DiagnosisMasters>(diagnosis => diagnosis.Description.ToLower() == desc.ToLower()).First();
        public DiagnosisMasters GetDiagnosisByName(string name) =>
            _diagnosisMasters.Find<DiagnosisMasters>(diagnosis => diagnosis.Name == name).FirstOrDefault();
        public DiagnosisMasters CreateDiagnosis(DiagnosisMasters id)
        {
            _diagnosisMasters.InsertOne(id);
            return id;
        }
        
        public void Update(string id, DiagnosisMasters diagnosisMasters) =>
            _diagnosisMasters.ReplaceOne(diagnosis => diagnosis.Id == id, diagnosisMasters);


    }

}

