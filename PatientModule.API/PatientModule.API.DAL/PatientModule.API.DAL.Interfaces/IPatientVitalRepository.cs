using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.DAL.PatientModule.API.DAL.Interfaces
{
  public  interface IPatientVitalRepository<T> where T:class
    {
        public Task<T> CreateVital(T _object);

        public IEnumerable<T> GetAllVital();

        public T GetByVitalId(int Id);

        public void DeleteVital(T _object);
    }
}
