using HRS.Busniess.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DesignationController : Controller
    {
        private readonly IDesignationRepository _repo;
        public DesignationController(IDesignationRepository empRepo)
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
                    return NotFound("Designatioin Detail Not Found / There is no entry");
                }
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
