using Azure.Core;
using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var emp = await _repo.GetAll();
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetSpecificEmp")]
        public async Task<IActionResult> GetSpecificEmp(int id)
        {
            try
            {
                var emp = await _repo.GetSpecificEmp(id);
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
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
        public async Task<IActionResult> UpdateEmployee(int id,Employee emp)
        {
            try
            {
                if (id != emp.Id)
                {
                    return NotFound();
                }

                if (emp == null)
                {
                    return BadRequest();
                }
                await _repo.UpdateEmployee(id,emp);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                var result = _repo.Delete(id);
                if (result == null)
                {
                    return BadRequest();
                }
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
