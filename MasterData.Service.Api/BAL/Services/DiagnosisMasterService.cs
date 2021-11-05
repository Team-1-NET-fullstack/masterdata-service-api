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

        public DiagnosisMasters GetDiagnosisByDescription(string desc)
        {
            try
            {
                return _diagnosisMasters.Find<DiagnosisMasters>(diagnosis => diagnosis.Description.ToLower() == desc.ToLower()).First();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        

        public async Task<DiagnosisMasters> CreateDiagnosis(DiagnosisMasters id)
        {
            //id.Id = null;
            await _diagnosisMasters.InsertOneAsync(id);
            return id;
        }

        public async Task UpdateAsync(string id, DiagnosisMasters diagnosisMasters) =>
           await _diagnosisMasters.ReplaceOneAsync(diagnosis => diagnosis.Id == id, diagnosisMasters);

    }

}

