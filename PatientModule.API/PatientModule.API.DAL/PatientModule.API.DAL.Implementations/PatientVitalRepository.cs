using PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Implementations
{
    public class PatientVitalRepository : IPatientVitalRepository<PatientVital>
    {
        private readonly CTGeneralHospitalContext _context;

        public PatientVitalRepository(CTGeneralHospitalContext context)
        {
            _context = context;
        }
        public async Task<PatientVital> CreateVital(PatientVital _object)
        {
            var obj = await _context.PatientVitals.AddAsync(_object);
            _context.SaveChanges();
            return obj.Entity;
        }

        public void DeleteVital(PatientVital _object)
        {
            _context.Remove(_object);
            _context.SaveChanges();
        }

        public IEnumerable<PatientVital> GetAllVital()
        {
            return _context.PatientVitals.ToList();
        }

        public PatientVital GetByVitalId(int Id)
        {
            return _context.PatientVitals.Where(s => s.PatientVitalId == Id).FirstOrDefault();

        }
    }
}
