using Microsoft.AspNetCore.Mvc;

namespace HRS.Client.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
