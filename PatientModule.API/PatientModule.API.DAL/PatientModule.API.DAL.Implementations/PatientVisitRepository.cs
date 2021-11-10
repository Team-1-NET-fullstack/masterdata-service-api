using Microsoft.EntityFrameworkCore;
using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Implementations
{
    public class PatientVisitRepository : IPatientVisitRepository<PatientVisit>
    {

        private readonly CTGeneralHospitalContext _context;

        public PatientVisitRepository(CTGeneralHospitalContext context)
        {
            _context = context;
        }
        public async Task<PatientVisit> CreateVisit(PatientVisit _object)
        {
            var obj = await _context.AddAsync(_object);

            //var query = _context.PatientVisits.Where(x => x.PatientVisitId == _object.PatientVisitId &&
            //                                         x.DiagnosisDescription == _object.DiagnosisDescription &&
            //                                         x.ProcedureDescription == _object.ProcedureDescription &&
            //                                         x.MedicationDescription == _object.MedicationDescription)
            //.Select(x => new { x.PatientVisitId, x.PatientVisitId });


            //var visit = _context.PatientVisits
            //.Include(x => x.AllergyDescription)
            //.Include(x => x.DiagnosisDescription)
            //.Include(x => x.ProcedureDescription)
            //.Include(x => x.MedicationDescription)
            //.Where(x => x.PatientVisitId == x.PatientVisitId)
            //.FirstOrDefault();

            _context.SaveChanges();
            return obj.Entity;
        }
         
        public void DeleteVisit(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

        public IEnumerable<PatientVisit> GetAll()
        {
            return _context.PatientVisits.ToList();
            //var masterquery = _context.DiagnosisMasters.Where(x => x.DiagnosisMastersId  ||
                                                     
            //                                         x.Diagnoses ||
            //                                         x.MedicationDescription == _object.MedicationDescription)
            //.Select(x => new { x.PatientVisitId, x.PatientId });
        }

        public PatientVisit GetByVisitId(int Id)
        {
            return _context.PatientVisits.Where(s => s.PatientVisitId == Id).FirstOrDefault();
        }

        public Task<PatientVisit> UpdateVisit(PatientVisit _object)
        {
            throw new NotImplementedException();
        }
    }
}
