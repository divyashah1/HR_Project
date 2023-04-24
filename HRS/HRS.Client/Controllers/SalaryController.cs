using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
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
        public async Task<ActionResult<List<SalaryViewModel>>> GetAll()
        {
            try
            {
                var emp = await _repo.GetAll();
                if (emp == null)
                {
                    return NotFound("Salary Detail Not Found / There is no entry");
                }
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddSalary(SalaryViewModel emp)
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
        public async Task<IActionResult> UpdateSalary(int id, SalaryViewModel emp)
        {
            try
            {


               
                if (id != emp.Id) return BadRequest("Please enter valid Id ");

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
                //if (result == null)
                //{
                //    return NotFound("Salary Detail Not Found / Please Enter valid salary Id");
                //}
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
