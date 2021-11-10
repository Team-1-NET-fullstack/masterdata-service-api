using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces
{
  public interface IAllergyRepository<T> where T : class
    {

        public Task<T> CreateAllergy(T _object);

        public IEnumerable<T> GetAllAllergy();

        public T GetByAllergyId(int Id);

        public void DeleteAllergy(T _object);

    }
}
