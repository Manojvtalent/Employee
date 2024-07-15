using Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Employee.DataAccess.IReosetories;
using System.Linq;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqWedAPIController : ControllerBase
    {
        public IEMPReposetoroy Iemprep;
        public LinqWedAPIController(IEMPReposetoroy _Iemprep)
        {
            this.Iemprep = _Iemprep;
        }
        [Route("InsertEmployees")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployees([FromBody] employee emp)
        {
            try
              {
            if (ModelState.IsValid)
            {
                var cout = await Iemprep.InsertEmployee(emp);
                return Ok(cout + "record Insert successfully...!");
            }
            else
            {
                return BadRequest(ModelState);
            }
              }
            catch (Exception ex)
            {
                return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            }
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
            var Emplist =(from x in await Iemprep.GetAll() select x).ToList();
            if (Emplist.Count != 0)
            {
                return Ok(Emplist);
            }
            else
            {
                return NotFound("there is no data available in the database table...!");
            }
             }
           catch (Exception ex)
            {
                return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            }
        }
       
       

        [Route("GetEmployeeByEmpId")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeByEmpId(int EmployeeNumber)
        {
            try
            {
                var Emplist = (from x in await Iemprep.GetAll() where x.EmployeeNumber==EmployeeNumber select x).ToList() ;
              if (Emplist != null)
              {
                return Ok(Emplist);
              }
              else
              {
                return NotFound("there is no data available in the database table...!");
              }
            }
            catch (Exception ex)
            {
                return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            }
        }
    }
}
