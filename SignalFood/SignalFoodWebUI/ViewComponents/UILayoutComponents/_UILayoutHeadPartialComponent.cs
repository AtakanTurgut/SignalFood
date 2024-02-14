using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutHeadPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
