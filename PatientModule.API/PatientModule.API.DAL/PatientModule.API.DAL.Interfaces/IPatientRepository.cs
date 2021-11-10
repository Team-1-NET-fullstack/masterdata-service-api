using PatientModule.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces
{
    public interface IPatientRepository<T> where T:class
    {
        public Task<T> Create(T _object);
  
        public IEnumerable<T> GetAll();

        public T GetById(int Id);
        public void Update(T _object);

        public void Delete(T _object);
        //public   void Update(int id, Patient patient);
        //public Task<T> Update(int id, T _object);

    }
}
