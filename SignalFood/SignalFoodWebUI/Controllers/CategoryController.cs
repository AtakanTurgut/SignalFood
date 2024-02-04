using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
