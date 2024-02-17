using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.ViewComponents.MenuComponents
{
    public class _MenuNavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
