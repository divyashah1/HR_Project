using HRS.Busniess.Abstraction;
using HRS.Busniess.ViewModel;
using HRS.Common;
using HRS.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : Controller
    {
        private readonly IManagerRepository _repo;
        
        public ManagerController(IManagerRepository empRepo)
        {
            _repo = empRepo;
          
        }



        [HttpGet]
        public async Task<ActionResult<CommonData<List<ManagerViewModel>>>> GetAll()
        {
            var ViewModel = await _repo.GetAll();
            if (ViewModel != null)
            {
                return Ok(new CommonData<IEnumerable<ManagerViewModel>>
                {
                    Status = true,
                    Message = "Get Data Successfully",
                    Data = ViewModel
                });
            }
            else
                return NotFound("Manager Not Found / there is no Details");

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CommonData<ManagerViewModel>>> GetSpecificManager(int id)
        {
            try
            {
                var emp = await _repo.GetSpecificManager(id);

                if (emp != null)
                {
                    return Ok(new CommonData<ManagerViewModel>
                    {
                        Status = true,
                        Message = "Get Data Specific Manager Id",
                        Data = emp

                    });
                }
                else
                    return NotFound("Manager Not Found /  Please Enter valid Manager Id");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult<CommonData<ManagerViewModel>>> AddManager(ManagerViewModel emp)
        {

            try
            {
                    await _repo.AddManager(emp);
                    return Ok(new CommonData<ManagerViewModel>
                    {
                        Status = true,
                        Message = "New manager information saved successfully.",
                        Data = emp
                    });

               

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


    }
}
