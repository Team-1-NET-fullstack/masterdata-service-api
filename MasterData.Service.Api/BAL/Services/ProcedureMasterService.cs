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
            _procedureMasters = database.GetCollection<ProcedureMasters>(settings.ProcedureCollection);
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
            _procedureMasters.Find<ProcedureMasters>(procedure => procedure.Description.ToLower() == desc.ToLower()).First();
       
        public async Task<ProcedureMasters> CreateProcedure(ProcedureMasters id)
        {

            await _procedureMasters.InsertOneAsync(id);
            return id;
        }
        public async Task<bool> UpdateAsync(ProcedureMasters procedureMasters)
        {
            var updateResult = await _procedureMasters.ReplaceOneAsync(filter: g => g.Id == procedureMasters.Id, replacement: procedureMasters);
            return updateResult.IsAcknowledged
                                && updateResult.ModifiedCount > 0;
        }
    }
}
