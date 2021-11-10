using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.BAL;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;

namespace PatientModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientVisitsController : ControllerBase
    {
        private readonly PatientVisitService _patientVisitService;

        private readonly IPatientVisitRepository<PatientVisit> _patientVisit;


        public PatientVisitsController(PatientVisitService patientVisitService, IPatientVisitRepository<PatientVisit> patientVisit)
        {
            _patientVisitService = patientVisitService;
            _patientVisit = patientVisit;
        }

        
        [HttpGet("GetAllVisit")]
        public Object GetAllVisit()
        {
            var data = _patientVisitService.GetAllVisits();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            }
            );
            return json;
        }

      
        [HttpGet("GetVisitById")]
        public Object GetVisitById(int id)
        {
            var data = _patientVisitService.GetVisitById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            }
            );
            return json;
        }

      
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutPatientVisit(int id, PatientVisit patientVisit)
        //{
        //    if (id != patientVisit.PatientVisitId)
        //    {
        //        return BadRequest();
        //    }

        //    _patientVisitService.Entry(patientVisit).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PatientVisitExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

       
        [HttpPost("AddVisit")]
        public async Task<Object> AddVisit([FromBody] PatientVisit patientVisit)
        {
            try
            {
                await _patientVisitService.AddVisit(patientVisit);
                return true;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error Patient visit not added" + ex);
            }
        }

        // DELETE: api/PatientVisits/5
        [HttpDelete("{id}")]
       
            public bool DeleteVisit(int id)
            {
                try
                {
                    _patientVisitService.DeleteVisit(id);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
          
        }       
    }

