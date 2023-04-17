using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : Controller
    {
        private readonly ILeaveRepository _repo;
        public LeaveController(ILeaveRepository empRepo)
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
                    return NotFound("Leave Detail Not Found /There is no details");
                }
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddLeave(Leave leave)
        {
            if (leave == null) return BadRequest();
            try
            {
                _repo.AddLeave(leave);
                return Ok(leave);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {

        //        var result = _repo.Delete(id);
        //        if (result == null)
        //        {
        //            return NotFound("leave Detail Not Found / Please Enter valid Attendance Id");
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
