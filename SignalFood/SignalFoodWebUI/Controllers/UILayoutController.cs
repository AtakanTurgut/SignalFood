using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
