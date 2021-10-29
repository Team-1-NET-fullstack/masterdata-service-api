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
        public ActionResult<List<DiagnosisMasters>> GetAll() =>
            _diagnosisMasterService.GetAllDiagnosis();


        [HttpGet(Name = "GetDiagnosisById")]
        public ActionResult<DiagnosisMasters> Get(string id)
        {
            var allergy = _diagnosisMasterService.GetDiagnosisById(id);

            if (allergy == null)
            {
                return NotFound();
            }

            return allergy;
        }

    }
}
