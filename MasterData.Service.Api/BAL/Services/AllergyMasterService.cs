using MasterData.Service.Api.DAL;
using MasterData.Service.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.BAL.Services
{
    public class AllergyMasterService
    {
        private readonly IMongoCollection<AllergyMasters> _allergyMasters;

        public AllergyMasterService(ICTGeneralHospitalDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);


            _allergyMasters = database.GetCollection<AllergyMasters>(settings.AllergyCollection);
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
            try {
                return _allergyMasters.Find<AllergyMasters>(allergy => allergy.Description.ToLower() == desc.ToLower()).First();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<AllergyMasters> CreateAllergy(AllergyMasters id)
        {
           
            await _allergyMasters.InsertOneAsync(id);
            return id;
        }

        public async Task UpdateAsync(AllergyMasters allergyMastersIn) =>
           await _allergyMasters.ReplaceOneAsync(allergy => allergy.Id == allergyMastersIn.Id, allergyMastersIn);
        
        }

    }



