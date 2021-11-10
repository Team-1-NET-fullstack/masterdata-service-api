//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PatientModule.API.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace PatientModule.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AllergyMasterController : ControllerBase
//    {
//        private readonly CTGeneralHospitalContext _context;

//        public AllergyMasterController(CTGeneralHospitalContext context)
//        {
//            _context = context;
//        }



//        // GET: api/<AllergyMasterController>
//        [HttpGet]
        
//        public async Task<ActionResult<IEnumerable<AllergyMaster>>> GetMasterAllergies()
//        {
//            return await _context.AllergyMasters.ToListAsync();
//        }

//        // GET api/<AllergyMasterController>/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<AllergyMaster>> GetMasterAllergy(int id)
//        {
//            var allergy = await _context.AllergyMasters.FindAsync(id);

//            if (allergy == null)
//            {
//                return NotFound();
//            }

//            return allergy;
//        }

//        // POST api/<AllergyMasterController>
     
//        [HttpPost]
//        public async Task<ActionResult<AllergyMaster>> PostMasterAllergy(AllergyMaster allergy)
//        {
//            _context.AllergyMasters.Add(allergy);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetAllergy", new { id = allergy.AllergyMastersId }, allergy);
//        }

//        //// PUT api/<AllergyMasterController>/5
//        //[HttpPut("{id}")]
//        //public void Put(int id, [FromBody] string value)
//        //{
//        //}

//        // DELETE api/<AllergyMasterController>/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteMasterAllergy(int id)
//        {
//            var allergy = await _context.AllergyMasters.FindAsync(id);
//            if (allergy == null)
//            {
//                return NotFound();
//            }

//            _context.AllergyMasters.Remove(allergy);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }
//    }
//}
