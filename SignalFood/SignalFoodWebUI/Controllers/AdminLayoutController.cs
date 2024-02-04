using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
