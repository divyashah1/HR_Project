using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{
    public class SalaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
