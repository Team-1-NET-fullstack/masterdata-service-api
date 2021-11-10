using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.BAL.PatientModule.API.BAL.Services
{
    public class AllergyService
    {
        private readonly IAllergyRepository<Allergy> _allergyRepository;
        public AllergyService(IAllergyRepository<Allergy> allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }
        public IEnumerable<Allergy> GetAllAllergy()
        {
            try
            {
                return _allergyRepository.GetAllAllergy().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Allergy> GetAllegyById(int id)
        {
            return _allergyRepository.GetAllAllergy().Where(x => x.PatientAllergyId == id).ToList();
        }
        public async Task<Allergy> AddAllergy(Allergy allergy)
        {
            return await _allergyRepository.CreateAllergy(allergy);
        }
        public bool DeleteAllergy(int id)
        {
            try
            {
                var DataList = _allergyRepository.GetAllAllergy().Where(x => x.PatientAllergyId == id).ToList();
                foreach (var item in DataList)
                {
                    _allergyRepository.DeleteAllergy(item);
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
