using MasterData.Service.Api.DAL;
using MasterData.Service.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.BAL.Services
{
    public class ProcedureMasterService
    {
        private readonly IMongoCollection<ProcedureMasters> _procedureMasters;

        public ProcedureMasterService(ICTGeneralHospitalDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _procedureMasters = database.GetCollection<ProcedureMasters>(settings.CTGeneralHospitalCollectionName3);
        }
        public List<ProcedureMasters> GetAllProcedure()
        {
            List<ProcedureMasters> procedureMasters;
            procedureMasters = _procedureMasters.Find(procedure => true).ToList();
            return procedureMasters;
        }
        public ProcedureMasters GetProcedureById(string id) =>
            _procedureMasters.Find<ProcedureMasters>(procedure => procedure.Id == id).FirstOrDefault();
        public ProcedureMasters GetProcedureByDescription(string desc) =>
            _procedureMasters.Find<ProcedureMasters>(procedure => procedure.Description == desc).First();
        public ProcedureMasters GetProcedureByName(string name) =>
            _procedureMasters.Find<ProcedureMasters>(procedure => procedure.Name == name).First();
        public ProcedureMasters CreateProcedure(ProcedureMasters id)
        {
            _procedureMasters.InsertOne(id);
            return id;
        }
        public void Update(string id, ProcedureMasters procedureMasters) =>
            _procedureMasters.ReplaceOne(procedure => procedure.Id == id, procedureMasters);
    }
}
