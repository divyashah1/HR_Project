using HRS.Busniess.Abstraction;
using HRS.Busniess.ViewModel;
using HRS.Common;
using HRS.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginRepository _repo;
        private readonly DataDbContext dataDbContext;
        public LoginController(ILoginRepository empRepo, DataDbContext dataDbContext)
        {
            _repo = empRepo;
            this.dataDbContext = dataDbContext;

        }



        [HttpGet]
        public async Task<ActionResult<CommonData<List<LoginViewModel>>>> GetAll()
        {
            var employeeViewModel = await _repo.GetAll();
            if (employeeViewModel != null)
            {
                return Ok(new CommonData<IEnumerable<LoginViewModel>>
                {
                    Status = true,
                    Message = "Get Data Successfully",
                    Data = employeeViewModel
                });
            }
            else
                return NotFound("ID Not Found / there is no Details");

        }





        [HttpGet("{id}")]
        public async Task<ActionResult<CommonData<LoginViewModel>>> GetSpecificLoginId(int id)
        {
            try
            {
                var emp = await _repo.GetSpecificLoginId(id);

                if (emp != null)
                {
                    return Ok(new CommonData<LoginViewModel>
                    {
                        Status = true,
                        Message = "Get Data Specific User Id",
                        Data = emp

                    });
                }
                else
                    return NotFound("User Not Found /  Please Enter valid User Id");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult<CommonData<LoginViewModel>>> Add(LoginViewModel emp)
        {

            try
            {

                bool data = this.dataDbContext.Login.Where(x => x.User_Name == emp.User_Name).Any();
                if (data)
                {
                    return BadRequest("The UserName is already taken, Add new UserName");
                }
                else
                {
                    await _repo.Add(emp);
                    return Ok(new CommonData<LoginViewModel>
                    {
                        Status = true,
                        Message = "New User information saved successfully.", 
                        Data = emp
                    });

                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
