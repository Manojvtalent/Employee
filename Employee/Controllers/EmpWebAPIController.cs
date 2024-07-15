using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Employee.DataAccess.IReosetories;
using Employee.Models;
using System.Diagnostics;
using Employee.Filters;
using WebAPI_Project.Filters;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MyActionFilter]
    [MyExceptionFilter]
    [MyResultFilter]
    public class EmpWebAPIController : ControllerBase
    {
        public IEMPReposetoroy Iemprep;
        public EmpWebAPIController(IEMPReposetoroy _Iemprep)
        {
            this.Iemprep = _Iemprep;
        }
       
        [Route("InsertEmployees")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployees([FromBody] employee emp)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    var cout = await Iemprep.InsertEmployee(emp);
                    return Ok(cout + "record Insert successfully...!");
                }
                else
                {
                    return BadRequest(ModelState);
                }
           // }
            //catch (Exception ex)
            //{
            //    return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            //}
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //try
            //{
          // throw new DivideByZeroException();
                var Emplist = await Iemprep.GetAll();
                if (Emplist.Count != 0)
                {
                    return Ok(Emplist);
                }
                else
                {
                    return NotFound("there is no data available in the database table...!");
                }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            //}
        }
        [Route("UpdateEmployee")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] employee emp)
        {
            //try
            //{
                var cout = await Iemprep.UpdateEmployee(emp);
                return Ok(cout + "record upadate successfully...!");
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            //}
        }
        [Route("DeleteEmployee")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int EmployeeNumber)
        {
            //try
            //{
                var cout = await Iemprep.DeleteEmployee(EmployeeNumber);
                return Ok(cout + "record upadate successfully...!");
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            //}
       
        }


        [Route("GetEmployeeByEmpId")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeByEmpId(int EmployeeNumber)
        {
            //try
            //{
                var Emplist = await Iemprep.GetEmployeeByEmpId(EmployeeNumber);
                if (Emplist != null)
                {
                    return Ok(Emplist);
                }
                else
                {
                    return NotFound("there is no data available in the database table...!");
                }
           // }
            //catch (Exception ex)
            //{
            //    return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            //}
        }
    }


}
