using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{
    public class LeaveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
