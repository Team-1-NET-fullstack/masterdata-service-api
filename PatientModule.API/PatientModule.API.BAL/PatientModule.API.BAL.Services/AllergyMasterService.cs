//using PatientModule.API.Models;
//using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PatientModule.API.PatientModule.API.BAL.PatientModule.API.BAL.Services
//{
//    public class AllergyMasterService
//    {
//        private readonly IAllergyMasterRepository<AllergyMaster> _allergyMasterRepository;
//        public AllergyMasterService(IAllergyMasterRepository<AllergyMaster> allergyMasterRepository)
//        {
//            _allergyMasterRepository = allergyMasterRepository;
//        }
//        public IEnumerable<AllergyMaster> GetAllMasterAllergy()
//        {
//            try
//            {
//                return _allergyMasterRepository.GetAllMasterAllergy().ToList();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public IEnumerable<AllergyMaster> GetMasterAllegyById(int id)
//        {
//            return _allergyMasterRepository.GetAllMasterAllergy().Where(x => x.AllergyMastersId == id).ToList();
//        }
//        public async Task<AllergyMaster> AddMasterAllergy(AllergyMaster allergy)
//        {
//            return await _allergyMasterRepository.CreateAllergyMasters(allergy);
//        }
//        public bool DeleteAllergy(int id)
//        {
//            try
//            {
//                var DataList = _allergyMasterRepository.GetAllMasterAllergy().Where(x => x.AllergyMastersId == id).ToList();
//                foreach (var item in DataList)
//                {
//                    _allergyMasterRepository.DeleteMasterAllergy(item);
//                }
//                return true;
//            }
//            catch (Exception)
//            {
//                return true;
//            }

//        }
//    }
//}