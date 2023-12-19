using Microsoft.AspNetCore.Mvc;

namespace GtApp.Components
{
    public class CampaignFilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
