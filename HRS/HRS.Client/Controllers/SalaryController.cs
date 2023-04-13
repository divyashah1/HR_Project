using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : Controller
    {

        private readonly ISalaryRepository _repo;
        public SalaryController(ISalaryRepository empRepo)
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


        [HttpPost]
        public async Task<IActionResult> AddSalary(Salary emp)
        {
            //if (emp == null) return BadRequest();
            try
            {
                await _repo.AddSalary(emp);
                return Ok();
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

          
        }


        [HttpPut]
        public async Task<IActionResult> UpdateSalary(int id, Salary emp)
        {
            try
            {


                if (emp == null)
                {
                    return NotFound();
                }
                if (id != emp.Id) return BadRequest();

                await _repo.UpdateSalary(id, emp);
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
