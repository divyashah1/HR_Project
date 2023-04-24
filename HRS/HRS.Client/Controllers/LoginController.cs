using HRS.Busniess.Abstraction;
using HRS.Busniess.Entities;
using HRS.Busniess.ViewModel;
using HRS.Common;
using HRS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRS.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration configuration; 
        private readonly ILoginRepository _repo;
        private readonly DataDbContext dataDbContext;
        public LoginController(IConfiguration configuration, ILoginRepository empRepo, DataDbContext dataDbContext)
        {
            _repo = empRepo;
            this.dataDbContext = dataDbContext;
            this.configuration = configuration;
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



        //[HttpPost]
        //public async Task<ActionResult<CommonData<LoginViewModel>>> Add(LoginViewModel emp)
        //{

        //    try
        //    {

        //        bool data = this.dataDbContext.Login.Where(x => x.User_Name == emp.User_Name).Any();
        //        if (data)
        //        {
        //            return BadRequest("The UserName is already taken, Add new UserName");
        //        }
        //        else
        //        {
        //            await _repo.Add(emp);
        //            return Ok(new CommonData<LoginViewModel>
        //            {
        //                Status = true,
        //                Message = "New User information saved successfully.",
        //                Data = emp
        //            });

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }

        //}

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel user)
        {

            try
            {
                if(user == null)
                {
                    return BadRequest();
                }

                //bool data = this.dataDbContext.Login.Where(x => x.User_Name == user.User_Name).Any();
                //if (data)
                //{
                //    return BadRequest("The UserName is already taken, Add new UserName");
                //}
                bool data = false;
                data = this.dataDbContext.Login.Where(x => x.User_Name == user.User_Name && x.Password == user.Password).Any();

                if (data)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(issuer: configuration["JWT:ValidIssuer"], audience: ConfigurationSettings.AppSettings["JWT:ValidAudience"], claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new TokenResponse 
                    {
                        Status = true,
                        Message = "New User information saved successfully.",
                        Token = tokenString
                    });
                    
                }
                return Unauthorized();
                //return BadRequest(new TokenResponse
                //{
                //    Error_Message = "User Not Verified"
                //}) ;

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
