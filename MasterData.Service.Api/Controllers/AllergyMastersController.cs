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
    public class AllergyMastersController : Controller
    {
       
            private readonly AllergyMasterService _allergyMasterService;

            public AllergyMastersController(AllergyMasterService allergyMasterService)
            {
            _allergyMasterService = allergyMasterService;
            }

            [HttpGet]
            public ActionResult<List<AllergyMasters>> GetAll() =>
                _allergyMasterService.GetAllAllergy();


        [HttpGet("{id:length(24)}", Name = "GetAllergyById")]
        public ActionResult<AllergyMasters> Get(string id)
        {
            var allergy = _allergyMasterService.GetAllergyById(id);

            if (allergy == null)
            {
                return NotFound();
            }

            return allergy;
        }
    }
    }

