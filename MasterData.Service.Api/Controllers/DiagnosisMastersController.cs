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
    public class DiagnosisMastersController : Controller
    {
        private readonly DiagnosisMasterService _diagnosisMasterService;

        public DiagnosisMastersController(DiagnosisMasterService diagnosisMasterService)
        {
            _diagnosisMasterService = diagnosisMasterService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<DiagnosisMasters>> GetAllDiagnosis() =>
            _diagnosisMasterService.GetAllDiagnosis();


        [HttpGet(Name = "GetDiagnosisById")]
        public ActionResult<DiagnosisMasters> GetDiagnosisbyId(string id)
        {
            var diagnosis = _diagnosisMasterService.GetDiagnosisById(id);

            if (diagnosis == null)
            {
                return NotFound();
            }

            return diagnosis;
        }

        //[HttpGet(Name = "GetDiagnosisByName")]
        //public ActionResult<DiagnosisMasters> GetName(string name)
        //{
        //    var diagnosis = _diagnosisMasterService.GetDiagnosisByName(name);

        //    if (diagnosis == null)
        //    {
        //        return NotFound();
        //    }

        //    return diagnosis;
        //}

        [HttpGet("GetDiagnosisByDescription")]
        public ActionResult<DiagnosisMasters> GetDesc(string desc)
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
            catch (Exception)
            {
                throw new KeyNotFoundException("Data not found");
            }
        }

        [HttpPost("CreateNewDiagnosis")]
        public ActionResult<DiagnosisMasters> Create(DiagnosisMasters id)
        {
            _diagnosisMasterService.CreateDiagnosis(id);
            return CreatedAtRoute("GetDiagnosisById", new { id = id.Id.ToString() }, id);
        }
        [HttpPut(Name = ("UpdateDiagnosis"))]
        public IActionResult UpdateDiagnosis(string id, DiagnosisMasters diagnosisMastersIn)
        {
            var diagnosis = _diagnosisMasterService.GetDiagnosisById(id);

            if (diagnosis == null)
            {
                return NotFound();
            }

            _diagnosisMasterService.Update(id, diagnosisMastersIn);

            return NoContent();
        }


    }
}
