using MasterData.Service.Api.BAL.Services;
using MasterData.Service.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationMastersController : Controller
    {
        private readonly MedicationMasterService _medicationMasterService;

        public MedicationMastersController(MedicationMasterService medicationMasterService)
        {
            _medicationMasterService = medicationMasterService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<MedicationMasters>> GetAllMedication() =>
            _medicationMasterService.GetAllMedication();


        [HttpGet(Name = "GetMedicationById")]
        public ActionResult<MedicationMasters> GetMedicationbyId(string id)
        {
            var medication = _medicationMasterService.GetMedicationById(id);

            if (medication == null)
            {
                return NotFound();
            }

            return medication;
        }

        [HttpGet("GetMedicationByDescription")]
        public ActionResult<MedicationMasters> GetMedicationbyDescription(string desc)
        {
            try
            {
                var medication = _medicationMasterService.GetMedicationByDescription(desc);

                if (medication == null)
                {
                    return NotFound();
                }

                return medication;
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("Data not found:" + e.Message);

            }
        }

        [HttpPost("CreateNewMedication")]
        public async Task<MedicationMasters> CreateMedication(MedicationMasters id)
        { 
            try
            {
                await _medicationMasterService.CreateMedication(id);
                return id;
            }
            catch (FormatException e)
            {
                throw new FormatException("Data not inserted:" + e.Message);
            }
        }

        
        [HttpPut("UpdateMedication")]
        public async Task<IActionResult> UpdateMedication(string id, MedicationMasters medicationMastersIn)
        {
            try
            {
                var medication = _medicationMasterService.GetMedicationById(id);

                if (medication == null)
                {
                    return NotFound();
                }

                await _medicationMasterService.UpdateAsync(id, medicationMastersIn);
                return NoContent();
            }
            catch (FormatException e)
            {
                throw new FormatException("Data not inserted:" + e.Message);
}
        }
          
            

    }
}
