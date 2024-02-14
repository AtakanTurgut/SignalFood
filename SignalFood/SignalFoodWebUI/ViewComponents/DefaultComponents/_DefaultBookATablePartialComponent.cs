using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultBookATablePartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
