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

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        var emp = await _repo.GetAll();
        //        if (emp == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(emp);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}


        [HttpGet("{id}", Name = "GetSpecificAtt")]
        public async Task<IActionResult> GetSpecificAttendance(int id)
        {
            try
            {
                var dep = await _repo.GetSpecificAttendance(id);
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


        [HttpPut]
        public async Task<IActionResult> UpdateAttendance(Attendance attendance)
        {
            try
            {

                if (attendance == null)
                {
                    return NotFound();
                }

                await _repo.UpdateAttendance(attendance);
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
