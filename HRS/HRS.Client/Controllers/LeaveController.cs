﻿using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using HRS.Common;
using HRS.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : Controller
    {
        private readonly ILeaveRepository _repo;
        private readonly DataDbContext dataDbContext;
        public LeaveController(ILeaveRepository empRepo , DataDbContext dataDbContext)
        {
            _repo = empRepo;
            this.dataDbContext = dataDbContext;

        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveViewModel>>> GetAll()
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
        public async Task<IActionResult> AddLeave(LeaveViewModel leave)
        {

            try
            {
                await _repo.AddLeave(leave);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<CommonData<LeaveViewModel>>> AddLeave(LeaveViewModel emp)
        //{

        //    try
        //    {

        //      bool data = this.dataDbContext.Leave.Where(x => x.emp_ID != emp.emp_ID).Any();
        //        if (data)
        //        {
        //            return BadRequest("employee not exits");
        //        }
        //        else
        //        {
        //            await _repo.AddLeave(emp);
        //            return Ok(new CommonData<LeaveViewModel>
        //            {
        //                Status = true,
        //                Message = "New Leave information saved successfully.",
        //                Data = emp
        //            });

        //        }

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
