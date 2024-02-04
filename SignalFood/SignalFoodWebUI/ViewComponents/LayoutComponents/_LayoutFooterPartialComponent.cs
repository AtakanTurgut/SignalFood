using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutFooterPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke() 
		{
			return View(); 
		}
	}
}
