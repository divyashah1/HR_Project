using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
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
        public async Task<ActionResult<DepartmentViewModel>> GetAll()
        {
            try
            {
                var dep = await _repo.GetAll();
                if (dep == null)
                {
                    return NotFound("Department Detail Not Found / there is no entry");
                }
                return Ok(dep);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetSpecificDept")]
        public async Task<ActionResult<DepartmentViewModel>> GetSpecificDept(int id)
        {
            try
            {
                var dep = await _repo.GetSpecificDept(id);
                if (dep == null)
                {
                    return NotFound("Department Detail Not Found / Please Enter valid Department Id");
                }
                return Ok(dep);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentViewModel>> AddDepartment(DepartmentViewModel dept)
        {
            try
            {
                await _repo.AddDepartment(dept);
                return Ok();

              //  return CreatedAtRoute("GetSpecificDept", new { id = dept.Id }, dept);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult> UpdateDept(int id,DepartmentViewModel dept)
        {
            try
            {

                if (dept == null)
                {
                    return NotFound("Department Detail Not Found / Please Enter valid Department Id");
                }

                await _repo.UpdateDept(id,dept);
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
                
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
