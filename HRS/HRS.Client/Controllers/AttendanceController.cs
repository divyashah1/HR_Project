using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using HRS.Common;
using HRS.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository _repo;
        private readonly DataDbContext dataDbContext;
        public AttendanceController(IAttendanceRepository Repo , DataDbContext dataDbContext)
        {
            _repo = Repo;
            this.dataDbContext = dataDbContext;
        }

                [HttpGet]
                public async Task<ActionResult<CommonData<List<AttendanceViewModel>>>> GetAll()
                {
                    try
                    {
                        return Ok(new CommonData<IEnumerable<AttendanceViewModel>>
                        {
                            Data = await _repo.GetAll(),
                            Status = true,
                            Message = "Get Data Successfully",
                        });
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
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


        [HttpGet("{id}/Employee")]
        public async Task<IActionResult> GetEmpById(int id)
        {
            try
            {
                return Ok(await _repo.GetEmpById(id));

               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("[action]")]
                public async Task<ActionResult<CommonData<AttendanceViewModel>>> AddAttendance(AttendanceViewModel attendance)
                {
                   
                        //if (attendance.Date_In != DateTime.Today) return BadRequest("Too late or Too early");
                        //var att = this.dataDbContext.Attendance.Any(i => i.emp_ID == attendance.emp_ID && i.Date_In == DateTime.Today);
                        //if (att) return BadRequest("Attendance Done");
                       // var user = await _repo.FindByNameAsync(attendance.emp_ID)
                        try
                        {
                                await _repo.AddAttendance(attendance);
                                return Ok(new CommonData<AttendanceViewModel>
                                {
                                    Status = true,
                                    Message = "New attendance information saved successfully.",
                                    Data = attendance
                                });

                        }
                       
                        catch (Exception ex)
                        {
                            return StatusCode(500, ex.Message);
                        }

            //return BadRequest();
                }


                [HttpPut("{id}")]
                public async Task<IActionResult> UpdateAttendance(int id, AttendanceViewModel attendance)
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
