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

        [HttpGet("GetAllAllergy")]
        public ActionResult<List<AllergyMasters>> GetAll()
        {
            try
            {
                return _allergyMasterService.GetAllAllergy();
            }
            catch (Exception)
            {
                throw new FileNotFoundException("File not found");
            }
        }

        [HttpGet("{id:length(24)}", Name = "GetAllergyById")]
        public ActionResult<AllergyMasters> Get(string id)
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
            catch (Exception)
            {
                throw new KeyNotFoundException("Data not found");
            }
        }

        [HttpGet("GetAllergyByDescription")]
        public ActionResult<AllergyMasters> GetDescription(string desc)
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
            catch (Exception)
            {
                throw new KeyNotFoundException("Data not found");
            }
        }

        [HttpPost("CreateNewAllergy")]
        public ActionResult<AllergyMasters> Create(AllergyMasters id)
        {
            _allergyMasterService.CreateAllergy(id);
            return CreatedAtRoute("GetAllergyById", new { id = id.Id.ToString() }, id);
        }
        [HttpPut("{id:length(24)}", Name = ("UpdateAllergy"))]
        public IActionResult Update(string id, AllergyMasters allergyMastersIn)
        {
            var allergy = _allergyMasterService.GetAllergyById(id);

            if (allergy == null)
            {
                return NotFound();
            }

            _allergyMasterService.Update(id, allergyMastersIn);

            return NoContent();
        }


    }
}

