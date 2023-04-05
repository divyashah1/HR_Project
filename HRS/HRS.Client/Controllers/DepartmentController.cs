using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repo;
        public DepartmentController(IDepartmentRepository Repo)
        {
            _repo = Repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var dep = await _repo.GetAll();
                if (dep == null)
                {
                    return NotFound();
                }
                return Ok(dep);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetSpecificDept")]
        public async Task<IActionResult> GetSpecificDept(int id)
        {
            try
            {
                var dep = await _repo.GetSpecificDept(id);
                if (dep == null)
                {
                    return NotFound();
                }
                return Ok(dep);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department dept)
        {
            try
            {
                await _repo.AddDepartment(dept);

                return CreatedAtRoute("GetSpecificDept", new { id = dept.Id }, dept);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDept(Department dept)
        {
            try
            {


                if (dept == null)
                {
                    return NotFound();
                }

                await _repo.UpdateDept(dept);
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
