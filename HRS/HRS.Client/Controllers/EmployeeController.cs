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
        public ActionResult AddEmployee(Employee emp)
        {
            if(emp == null) return BadRequest();
            try
            {
                _repo.AddEmployee(emp);
                return Ok(emp);
                //     _repo.AddEmployee(emp);

                //    return CreatedAtRoute("GetSpecificEmp", new { id = emp.Id }, emp);
                //}
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
            try
            {


                if (emp == null)
                {
                    return NotFound();
                }

                await _repo.UpdateEmployee(emp);
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
