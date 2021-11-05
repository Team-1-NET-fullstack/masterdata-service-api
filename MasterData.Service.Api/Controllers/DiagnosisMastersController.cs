using MasterData.Service.Api.BAL.Services;
using MasterData.Service.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisMastersController : Controller
    {
        private readonly DiagnosisMasterService _diagnosisMasterService;

        public DiagnosisMastersController(DiagnosisMasterService diagnosisMasterService)
        {
            _diagnosisMasterService = diagnosisMasterService;
        }

        [HttpGet("GetDiagnosisById")]
        public ActionResult<DiagnosisMasters> GetDiagnosisbyId(string id)
        {
            try
            {
                var diagnosis = _diagnosisMasterService.GetDiagnosisById(id);

                if (diagnosis == null)
                {
                    return NotFound();
                }

                return diagnosis;
            
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("Data not found:" + e.Message);

    }
}

        [HttpGet("GetDiagnosisByDescription")]
        public ActionResult<DiagnosisMasters> GetDescriptionDiagnosis(string desc)
        {
            try
            {
                var diagnosis = _diagnosisMasterService.GetDiagnosisByDescription(desc);

                if (diagnosis == null)
                {
                    return NotFound();
                }

                return diagnosis;
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("Data not found:" + e.Message);

            }
        }

        [HttpPost("CreateNewDiagnosis")]
        public async Task<DiagnosisMasters> CreateNewDiagnosis(DiagnosisMasters id)
        {
            try
            {
                await _diagnosisMasterService.CreateDiagnosis(id);
                return id;
            }
            catch (FormatException e)
            {
                throw new FormatException("Data not inserted:" + e.Message);
            }
        }



        [HttpPut("UpdateDiagnosis")]
        public async Task<IActionResult> UpdateDiagnosis(string id, DiagnosisMasters diagnosisMastersIn)
        {
            try {
                var diagnosis = _diagnosisMasterService.GetDiagnosisById(id);
                if (diagnosis == null)
                {
                    return NotFound();
                }
                await _diagnosisMasterService.UpdateAsync(id, diagnosisMastersIn);
                return NoContent();
            }
            catch (FormatException e)
            {
                throw new FormatException("Data not inserted:" + e.Message);
            }
        }


    }
}
