using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
