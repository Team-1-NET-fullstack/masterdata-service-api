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
    public class AllergyMastersController : Controller
    {

        private readonly AllergyMasterService _allergyMasterService;

        public AllergyMastersController(AllergyMasterService allergyMasterService)
        {
            _allergyMasterService = allergyMasterService;
        }
        [HttpGet]
        public ActionResult<List<AllergyMasters>> Get() =>
          _allergyMasterService.GetAllAllergy();


        [HttpGet("GetAllergybyId")]
        public ActionResult<AllergyMasters> GetAllergybyId(string id)
        {
            try
            {
                var allergy = _allergyMasterService.GetAllergyById(id);

                if (allergy == null)
                {
                    return NotFound();
                }

                return allergy;
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("Data not found:" + e.Message);

            }
        }

        [HttpGet("GetAllergyByDescription")]
        public ActionResult<AllergyMasters> GetDescriptionAllergy(string desc)
        {
            try
            {
                var allergy = _allergyMasterService.GetAllergyByDescription(desc);

                if (allergy==null)
                {
                    return NotFound();
                }

                return allergy;
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("Desc not found:" + e.Message);

            }
        }

        [HttpPost("CreateNewAllergy")]
        public async Task<AllergyMasters> CreateAllergy(AllergyMasters id)
        {
            try
            {
               await _allergyMasterService.CreateAllergy(id);
                return id;
            }
            catch(FormatException e)
            {
                throw new FormatException("Data not inserted:" + e.Message);
            }
        }
       
        [HttpPut("UpdateAllergy")]

        public async Task<IActionResult> UpdateAllergy([FromBody] AllergyMasters allergyMastersIn)
        {
            return Ok(await _allergyMasterService.UpdateAsync(allergyMastersIn));
        }



    }
}

