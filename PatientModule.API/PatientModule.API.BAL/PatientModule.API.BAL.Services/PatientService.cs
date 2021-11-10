using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.BAL.PatientModule.API.BAL.Services
{
    public class PatientService
    {
        private readonly IPatientRepository<Patient> _patientRepository;
        public PatientService(IPatientRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;

        }

        //GET All Patient Details   
        public IEnumerable<Patient> GetAllVisits()
        {
            try
            {
                return (IEnumerable<Patient>)_patientRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get Notes By Id  
        public IEnumerable<Patient> GetPatientById(int id)
        {
            return _patientRepository.GetAll().Where(x => x.PatientId == id).ToList();
        }

        //Add Patient
        public async Task<Patient> AddPatient(Patient patient)
        {
            patient.CreatedDate = DateTime.Now;
            patient.UpdatedDate = DateTime.Now;

            return await _patientRepository.Create(patient);
        }
        public bool UpdatePatient(Patient patient,int id)
        {
            try
            {
                var DataList = _patientRepository.GetAll().Where(x => x.PatientId==id).ToList();
                foreach (var item in DataList)
                {
                    _patientRepository.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        //Update Patient
        //public bool UpdatePatient(int id,Patient patient)
        //{
        //    _patientRepository.Update(patient);
        //    return true;
        //}
        //Delete Patient   
        public bool DeleteVisit(int id)
        {
            try
            {
                var DataList = _patientRepository.GetAll().Where(x => x.PatientId == id).ToList();
                foreach (var item in DataList)
                {
                    _patientRepository.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

      

        //public Task<Patient> UpdatePatient(int id, Patient patient)
        //{
        //    var patientEdit = _patientRepository.Update(id, patient);
        //    return patientEdit;
        //}
    }
}

