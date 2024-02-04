using Microsoft.AspNetCore.Mvc;

namespace SignalFoodWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View(); 
        }
    }
}
