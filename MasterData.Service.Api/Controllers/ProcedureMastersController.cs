using MasterData.Service.Api.BAL.Services;
using MasterData.Service.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureMastersController : Controller
    {
        private readonly ProcedureMasterService _procedureMasterService;

        public ProcedureMastersController(ProcedureMasterService procedureMasterService)
        {
            _procedureMasterService = procedureMasterService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<ProcedureMasters>> GetAllProcedure()
        {
            try
            {
                return _procedureMasterService.GetAllProcedure();

            }
            catch (Exception e)
            {
                throw new FileNotFoundException("Data not found:" + e.Message);

            }
        }

[HttpGet(Name = "GetProcedureById")]
        public ActionResult<ProcedureMasters> GetProcedurebyId(string id)
        {
            try { 
            var procedure = _procedureMasterService.GetProcedureById(id);

            if (procedure == null)
            {
                return NotFound();
            }

            return procedure;
        }
            catch (Exception e)
            {
                throw new KeyNotFoundException("Data not found:" + e.Message);

    }
}


        [HttpGet("GetProcedureByDescription")]
        public ActionResult<ProcedureMasters> GetProcedurebyDescription(string desc)
        {
            try
            {
                var procedure = _procedureMasterService.GetProcedureByDescription(desc);

                if (procedure == null)
                {
                    return NotFound();
                }

                return procedure;
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("Desc not found:"+e.Message);

            }
        }

        [HttpPost("CreateNewProcedure")]
        public ActionResult<ProcedureMasters> CreateProcedure(ProcedureMasters id)
        {
            try { 
            //id.Id = "0";
            //id.ProcedureMastersId = "0";
            _procedureMasterService.CreateProcedure(id);
            return CreatedAtRoute("GetProcedureById", new { id = id.ProcedureMastersId.ToString() }, id);
            }
            catch (FormatException e)
            {
                throw new FormatException("Data not inserted:" + e.Message);
            }
        }
        [HttpPut("UpdateProcedure")]
        public IActionResult UpdateProcedure(string id, ProcedureMasters procedureMastersIn)
        {
            try
            {
                var procedure = _procedureMasterService.GetProcedureById(id);

                if (procedure == null)
                {
                    return NotFound();
                }

                _procedureMasterService.UpdateProcedure(id, procedureMastersIn);

                return NoContent();
            }
            catch (FormatException e)
            {
                throw new FormatException("Data not inserted:" + e.Message);
            }
        }

    }
}
