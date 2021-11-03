﻿using MasterData.Service.Api.DAL;
using MasterData.Service.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.BAL.Services
{

    public class MedicationMasterService
    {
        private readonly IMongoCollection<MedicationMasters> _medicationMasters;

        public MedicationMasterService(ICTGeneralHospitalDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _medicationMasters = database.GetCollection<MedicationMasters>(settings.MedicationCollection);
        }
        public List<MedicationMasters> GetAllMedication()
        {
            List<MedicationMasters> medicationMasters;
            medicationMasters = _medicationMasters.Find(medication => true).ToList();
            return medicationMasters;
        }
        public MedicationMasters GetMedicationById(string id) =>
            _medicationMasters.Find<MedicationMasters>(medication => medication.Id == id).FirstOrDefault();
        public MedicationMasters GetMedicationByDescription(string desc) =>
            _medicationMasters.Find<MedicationMasters>(medication => medication.Description.ToLower() == desc.ToLower()).First();
        public MedicationMasters GetMedicationByName(string name) =>
            _medicationMasters.Find<MedicationMasters>(medication => medication.Name == name).First();
        public MedicationMasters CreateMedication(MedicationMasters id)
        {
            _medicationMasters.InsertOne(id);
            return id;
        }
        public void Update(string id, MedicationMasters medicationMasters) =>
            _medicationMasters.ReplaceOne(medication => medication.Id == id, medicationMasters);
    }
}
