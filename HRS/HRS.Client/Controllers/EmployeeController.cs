using Azure.Core;
using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using HRS.Common;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Security.AccessControl;

namespace HRS.Client.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeController(IEmployeeRepository empRepo)
        {
            _repo = empRepo;
        }


        [HttpGet]
        public async Task<ActionResult<CommonData<List<Employee>>>> GetAll()
        {
            var emp = await _repo.GetAll();
            if (emp != null)
            {
                return Ok(new CommonData<IEnumerable<Employee>>
                {
                    Status = true,
                    Message = "Get Data Successfully",
                    Data = emp

                });
            }
            else
                return NotFound("Employee Not Found / there is no Details");



        }

        [HttpGet("{id}", Name = "GetSpecificEmp")]
        public async Task<ActionResult<CommonData<Employee>>> GetSpecificEmp(int id)
        {
            try
            {
                var emp = await _repo.GetSpecificEmp(id);
               
                if(emp != null) 
                {
                    return Ok(new CommonData<Employee>
                    {
                        Status = true,
                        Message = "Get Data Specific Employee Id",
                        Data = emp

                    });
                }
                else
                    return NotFound("Employee Not Found /  Please Enter valid employee Id");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {

            try
            {
                await _repo.AddEmployee(emp);
                return CreatedAtRoute("GetSpecificEmp", new { id = emp.Id }, emp);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpPut]
        public async Task<ActionResult<CommonData<Employee>>> UpdateEmployee(int id, Employee emp)
        {
            try
            {
                await _repo.UpdateEmployee(id, emp);

                if (id != emp.Id)
                {
                    return BadRequest("Please enter valid Id ");
                }

               
              

                return Ok(new CommonData<IEnumerable<int>>
                {
                    Status = true,
                    Message = "Data Updated Succcessfully",
                });


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CommonData<Employee>>> Delete(int id)
        {
            try
            {

                var result = _repo.Delete(id);
                return Ok(new CommonData<IEnumerable<int>>
                {
                    Status = true,
                    Message = "Data deleted Succcessfully",
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        var emp = await _repo.GetAll();
        //        if (emp == null)
        //        {
        //            return NotFound("Employee Not Found / there is no Details");
        //        }
        //        return Ok(emp);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}







        //[HttpGet("{id}", Name = "GetSpecificEmp")]
        //public async Task<IActionResult> GetSpecificEmp(int id)
        //{
        //    try
        //    {
        //        var emp = await _repo.GetSpecificEmp(id);
        //        if (emp == null)
        //        {
        //            return NotFound("Employee Not Found / Please Enter valid employee Id");
        //        }
        //        return Ok(emp);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddEmployee(Employee emp)
        //{
         
        //    try
        //    {
        //        await _repo.AddEmployee(emp);
        //        return CreatedAtRoute("GetSpecificEmp", new { id = emp.Id }, emp);
                
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }

        //}


        //[HttpPut]
        //public async Task<IActionResult> UpdateEmployee(int id,Employee emp)
        //{
        //    try
        //    {
        //        if (id != emp.Id)
        //        {
        //            return BadRequest("Please enter valid Id ");
        //        }

        //        if (emp == null)
        //        {
        //            return NotFound("Employee Not Found / Please Enter valid employee Id");
        //        }
        //        await _repo.UpdateEmployee(id,emp);
        //        return NoContent();

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }


        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {

        //        var result = _repo.Delete(id);
        //        if (result == null)
        //        {
        //            return NotFound("Employee Not Found / Please Enter valid employee Id");
        //        }
        //        return NoContent();

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}
