using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Implementations
{
    public class AllergyRepository : IAllergyRepository<Allergy>
    {
        private CTGeneralHospitalContext _dbContext;
        public AllergyRepository(CTGeneralHospitalContext context)
        {
            _dbContext = context;
        }

        public async Task<Allergy> CreateAllergy(Allergy _object)
        {
            var obj = await _dbContext.Allergies.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;

        }

        public void DeleteAllergy(Allergy _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Allergy> GetAllAllergy()
        {
            return _dbContext.Allergies.ToList();
        }

        public Allergy GetByAllergyId(int Id)
        {
            return _dbContext.Allergies.Where(s => s.PatientAllergyId == Id).FirstOrDefault();
        }
    }
}
