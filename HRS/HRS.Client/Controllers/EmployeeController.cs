using Azure.Core;
using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using HRS.Common;
using HRS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Eventing.Reader;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace HRS.Client.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;
        private readonly DataDbContext dataDbContext;
        public EmployeeController(IEmployeeRepository empRepo, DataDbContext dataDbContext)
        {
            _repo = empRepo;
            this.dataDbContext = dataDbContext;

        }

        

        [HttpGet]
        public async Task<ActionResult<CommonData<List<EmployeeViewModel>>>> GetAll()
        {
            var employeeViewModel= await _repo.GetAll();
            if (employeeViewModel != null)
            {
                return Ok(new CommonData<IEnumerable<EmployeeViewModel>>
                {
                    Status = true,
                    Message = "Get Data Successfully",
                    Data = employeeViewModel
                });
            }
            else
                return NotFound("Employee Not Found / there is no Details");

        }





        [HttpGet("{id}", Name = "GetSpecificEmp")]
        public async Task<ActionResult<CommonData<EmployeeViewModel>>> GetSpecificEmp(int id)
        {
            try
            {
                var emp = await _repo.GetSpecificEmp(id);

                if (emp != null)
                {
                    return Ok(new CommonData<EmployeeViewModel>
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



        //[HttpGet("{id}/Des")]
        //public async Task<ActionResult<CommonData<DesignationViewModel>>> GetSpecificDes_Name(int id)
        //{
        //    try
        //    {

        //        return Ok(new CommonData<DesignationViewModel>
        //        {
        //            Data = await _repo.GetSpecificDes_Name(id),
        //            Status = true,
        //            Message = "Get Data Specific Employee Id",


        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}



        [HttpPost]
        public async Task<ActionResult<CommonData<EmployeeViewModel>>> AddEmployee(EmployeeViewModel emp)
        {

            try
            {

               bool data=this.dataDbContext.Employee.Where(x=>x.Name == emp.Name).Any();
               if(data)
                {
                    return BadRequest("The employee name is already taken, Add new Employee name");
                }
                else
                {
                    await _repo.AddEmployee(emp);
                    return Ok(new CommonData<EmployeeViewModel>
                    {
                        Status = true,
                        Message = "New Employee information saved successfully.",
                        Data = emp
                    });

                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpPut]
        public async Task<ActionResult<CommonData<int>>> UpdateEmployee(int id, EmployeeViewModel emp)
        {
            try
            {
             
                if (id != emp.Id)
                {
                    return BadRequest("Please enter valid Id ");
                }
                await _repo.UpdateEmployee(id, emp);

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
        public async Task<ActionResult<CommonData<EmployeeViewModel>>> Delete(int id)
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
