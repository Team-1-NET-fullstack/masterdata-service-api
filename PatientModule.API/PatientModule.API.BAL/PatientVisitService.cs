using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.BAL
{
    public class PatientVisitService
    {
        private readonly IPatientVisitRepository<PatientVisit> _patientVisitRepository;
        public PatientVisitService(IPatientVisitRepository<PatientVisit> patientVisitRepository)
        {
            _patientVisitRepository = patientVisitRepository;

        }

        //GET All Patient Details   
        public IEnumerable<PatientVisit> GetAllVisits()
        {
            try
            {
                return (IEnumerable<PatientVisit>)_patientVisitRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get Patient By Id  
        public IEnumerable<PatientVisit> GetVisitById(int id)
        {
            return _patientVisitRepository.GetAll().Where(x => x.PatientVisitId == id).ToList();
        }

        //Add Note
        public async Task<PatientVisit> AddVisit(PatientVisit patient)
        {
            //patient.StartTime=DateTime.;
            return await _patientVisitRepository.CreateVisit(patient);
        }
        //Delete Patient   
        public bool DeleteVisit(int id)
        {
            try
            {
                var DataList = _patientVisitRepository.GetAll().Where(x => x.PatientVisitId == id).ToList();
                foreach (var item in DataList)
                {
                    _patientVisitRepository.DeleteVisit(id);
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
