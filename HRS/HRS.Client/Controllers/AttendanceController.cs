using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository _repo;
        public AttendanceController(IAttendanceRepository Repo)
        {
            _repo = Repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var emp = await _repo.GetAll();
                if (emp == null)
                {
                    return NotFound("Attendance Details Not Found / There is no Details");
                }
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}", Name = "GetSpecificAtt")]
        public async Task<IActionResult> GetSpecificAttendance(int id)
        {
            try
            {
                var dep = await _repo.GetSpecificAttendance(id);
                if (dep == null)
                {
                    return NotFound("Attendance Detail Not Found / Please Enter valid Attendance Id");
                }
                return Ok(dep);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAttendance(Attendance attendance)
        {
            try
            {
                await _repo.AddAttendance(attendance);

                return CreatedAtRoute("GetSpecificAtt", new { id = attendance.ID }, attendance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
     

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, Attendance attendance)
        {
            try
            {
                if (id != attendance.ID)
                {
                    return BadRequest("Please enter valid Id ");
                }

                if (attendance == null)
                {
                    return NotFound("Attendance Detail Not Found / Please Enter valid Attendance Id");
                }

                await _repo.UpdateAttendance(id,attendance);
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
                    return NotFound("Attendance Detail Not Found / Please Enter valid Attendance Id");
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
