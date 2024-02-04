using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
