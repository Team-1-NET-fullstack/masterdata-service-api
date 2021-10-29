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
    public class ProcedureMastersController : Controller
    {
        private readonly ProcedureMasterService _procedureMasterService;

        public ProcedureMastersController(ProcedureMasterService procedureMasterService)
        {
            _procedureMasterService = procedureMasterService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<ProcedureMasters>> GetAll() =>
            _procedureMasterService.GetAllProcedure();


        [HttpGet(Name = "GetProcedureById")]
        public ActionResult<ProcedureMasters> Get(string id)
        {
            var procedure = _procedureMasterService.GetProcedureById(id);

            if (procedure == null)
            {
                return NotFound();
            }

            return procedure;
        }

        [HttpGet(Name = "GetProcedureByName")]
        public ActionResult<ProcedureMasters> GetName(string id)
        {
            var procedure = _procedureMasterService.GetProcedureByName(id);

            if (procedure == null)
            {
                return NotFound();
            }

            return procedure;
        }

        [HttpGet("GetProcedureByDescription")]
        public ActionResult<ProcedureMasters> GetDescription(string desc)
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
            catch (Exception)
            {
                throw new KeyNotFoundException("Data not found");
            }
        }

        [HttpPost("CreateNewProcedure")]
        public ActionResult<ProcedureMasters> Create(ProcedureMasters id)
        {
            _procedureMasterService.CreateProcedure(id);
            return CreatedAtRoute("GetProcedureById", new { id = id.Id.ToString() }, id);
        }
        [HttpPut("UpdateProcedure")]
        public IActionResult Update(string id, ProcedureMasters procedureMastersIn)
        {
            var procedure = _procedureMasterService.GetProcedureById(id);

            if (procedure == null)
            {
                return NotFound();
            }

            _procedureMasterService.Update(id, procedureMastersIn);

            return NoContent();
        }

    }
}
