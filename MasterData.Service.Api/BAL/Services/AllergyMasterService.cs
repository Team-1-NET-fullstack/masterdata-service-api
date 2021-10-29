﻿using MasterData.Service.Api.DAL;
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


            _allergyMasters = database.GetCollection<AllergyMasters>(settings.CTGeneralHospitalCollectionName1);
        }
        public List<AllergyMasters> GetAllAllergy()
        {
            List<AllergyMasters> allergyMasters;
            allergyMasters = _allergyMasters.Find(allergy => true).ToList();
            return allergyMasters;
        }
        public AllergyMasters GetAllergyById(string id) =>
            _allergyMasters.Find<AllergyMasters>(allergy => allergy.Id == id).FirstOrDefault();

        public AllergyMasters GetAllergyByDescription(string desc) =>
            _allergyMasters.Find<AllergyMasters>(allergy => allergy.Description == desc).First();
        public AllergyMasters CreateAllergy(AllergyMasters id)
        {
            _allergyMasters.InsertOne(id);
            return id;
        }
        public void Update(string id, AllergyMasters allergyMasters) =>
            _allergyMasters.ReplaceOne(allergy => allergy.Id == id, allergyMasters);


    }

}
