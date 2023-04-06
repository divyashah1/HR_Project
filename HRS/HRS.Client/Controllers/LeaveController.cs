using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{

    //[ApiController]
    //[Route("api/[controller]")]
    public class LeaveController : Controller
    {
        //private readonly ILeaveRepository _repo;
        //public LeaveController(ILeaveRepository empRepo)
        //{
        //    _repo = empRepo;
        //}

        //[HttpPost]
        //public ActionResult AddLeave(Leave leave)
        //{
        //    if (leave == null) return BadRequest();
        //    try
        //    {
        //        _repo.AddLeave(leave);
        //        return Ok(leave);
                
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
        //            return BadRequest();
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
