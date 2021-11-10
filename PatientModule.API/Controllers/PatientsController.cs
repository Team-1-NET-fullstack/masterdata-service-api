using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.BAL.PatientModule.API.BAL.Services;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;

namespace PatientModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _patientService;

        private readonly IPatientRepository<Patient> _patientRepository;

        public PatientsController(IPatientRepository<Patient> patientRepository, PatientService patientService)
        {
            _patientService = patientService;
            _patientRepository = patientRepository;

        }

        //GET All Patients
        [HttpGet("GetAllPatients")]
        public Object GetAllPatients()
        {
            try
            {
                var data = _patientService.GetAllVisits();
                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                return json;

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error displaying patient record  " + ex);
            }
        }
        //GET All Patient by ID
        [HttpGet("GetPatientById")]
        public Object GetPatientById(int id)
        {
            var data = _patientService.GetPatientById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }


        //Add Patient 
        [HttpPost("AddPatient")]
        public async Task<Object> AddPatient([FromBody] Patient patient)
        {
            try
            {
                await _patientService.AddPatient(patient);
                return true;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new patient record  " + ex);
            }
        }
        //Delete Patient  
        [HttpDelete("DeletePatient")]
        public bool DeletePatient(int id)
        {
            try
            {
                _patientService.DeleteVisit(id);
                return true;
            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError , ex);
                return false;
            }
        }
     

       
        [HttpPut("UpdatePatient")]
        public bool UpdatePatient(Patient Object,int id)
        {
            try
            {
                _patientService.UpdatePatient(Object,id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

}

