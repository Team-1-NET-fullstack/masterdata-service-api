﻿using MasterData.Service.Api.BAL.Services;
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

        //[HttpGet(Name = "GetMedicationByName")]
        //public ActionResult<MedicationMasters> GetMedicationbyName(string id)
        //{
        //    var medication = _medicationMasterService.GetMedicationByName(id);

        //    if (medication == null)
        //    {
        //        return NotFound();
        //    }

        //    return medication;
        //}

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
        public ActionResult<MedicationMasters> CreateMedication(MedicationMasters id)
        {
            _medicationMasterService.CreateMedication(id);
            return CreatedAtRoute("GetMedicationById", new { id = id.Id.ToString() }, id);
        }
        [HttpPut("UpdateMedication")]
        public IActionResult UpdateMedication(string id, MedicationMasters medicationMastersIn)
        {
            var medication = _medicationMasterService.GetMedicationById(id);

            if (medication == null)
            {
                return NotFound();
            }

            _medicationMasterService.Update(id, medicationMastersIn);

            return NoContent();
        }

    }
}
