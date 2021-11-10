using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Implementations
{
    public class PatientRepository: IPatientRepository<Patient>
    {
        private readonly CTGeneralHospitalContext _context;
        public PatientRepository(CTGeneralHospitalContext context)
        {
            _context = context;
        }

        public async Task<Patient> Create(Patient _object)
        {
            var obj = await _context.Patients.AddAsync(_object);
            _context.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Patient _object)
        {
            _context.Remove(_object);
            _context.SaveChanges();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return _context.Patients.Where(s => s.PatientId == id).FirstOrDefault();
        }

        public void Update(Patient _object)
        {
            _context.Patients.Update(_object);
            _context.SaveChanges();
        }
        //        //public  Task<Patient> Update(int id, Patient patient)


        public async Task<Patient> Update(int id, Patient patient)
        {
            var entity = _context.Patients.FirstOrDefault(e => e.PatientId == id);

            entity.Title = patient.Title;
            entity.FirstName = patient.FirstName;
            entity.LastName = patient.LastName;
            entity.Gender = patient.Gender;
            entity.Race = patient.Race;
            entity.Languages = patient.Languages;
            entity.Email = patient.Email;
            entity.Address = patient.Address;
            entity.PinCode = patient.PinCode;
            entity.CountryCode = patient.CountryCode;
            entity.ContactNumber = patient.ContactNumber;
            entity.EmergencyContact = patient.EmergencyContact;
            _context.SaveChanges();
            return entity;

        }


    }
}

