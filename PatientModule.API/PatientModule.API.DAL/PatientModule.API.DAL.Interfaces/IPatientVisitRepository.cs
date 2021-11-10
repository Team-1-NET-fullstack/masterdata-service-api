using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces
{
  public  interface IPatientVisitRepository<T>where T:class
    {
        public Task<T> CreateVisit(T _object);
        public Task<T> UpdateVisit(T _object);
        public IEnumerable<T> GetAll();
        public T GetByVisitId(int Id);
        public void DeleteVisit(int id);
    }
}
