﻿using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
