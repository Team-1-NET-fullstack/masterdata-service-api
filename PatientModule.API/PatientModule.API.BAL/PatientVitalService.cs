using PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.BAL
{
    public class PatientVitalService
    {
        private readonly IPatientVitalRepository<PatientVital> _patientVitalRepository;
        public PatientVitalService(IPatientVitalRepository<PatientVital> patientVitalRepository)
        {
            _patientVitalRepository = patientVitalRepository;
        }
        public IEnumerable<PatientVital> GetAllVitals()
        {
            try
            {
                return _patientVitalRepository.GetAllVital().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<PatientVital> GetVitalById(int id)
        {
            return _patientVitalRepository.GetAllVital().Where(x => x.PatientVitalId == id).ToList();
        }
        public async Task<PatientVital> AddVital(PatientVital patientVital)
        {
            return await _patientVitalRepository.CreateVital(patientVital);
        }
        public bool DeleteVital(int id)
        {
            try
            {
                var DataList = _patientVitalRepository.GetAllVital().Where(x => x.PatientVitalId == id).ToList();
                foreach (var item in DataList)
                {
                    _patientVitalRepository.DeleteVital(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

    }
}