//using PatientModule.API.Models;
//using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Implementations
//{
//    public class AllergyMasterRepository : IAllergyMasterRepository<AllergyMaster>
//    {
//        private readonly CTGeneralHospitalContext _context;
//        public AllergyMasterRepository(CTGeneralHospitalContext context)
//        {
//            _context = context;
//        }

//        public async Task<AllergyMaster> CreateAllergyMasters(AllergyMaster _object)
//        {

//            var obj = await _context.AllergyMasters.AddAsync(_object);
//            _context.SaveChanges();
//            return obj.Entity;
//        }

//        public void DeleteMasterAllergy(AllergyMaster _object)
//        {
//            _context.Remove(_object);
//            _context.SaveChanges();
//        }

//        public IEnumerable<AllergyMaster> GetAllMasterAllergy()
//        {
//            return _context.AllergyMasters.ToList();
//        }

//        public AllergyMaster GetByMasterAllergyId(int Id)
//        {
//            return _context.AllergyMasters.Where(s => s.AllergyMastersId == Id).FirstOrDefault();
//        }
//    }
//}
