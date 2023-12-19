using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Components
{
    public class ProfileMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ProfileMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var profiles = _manager.SubmissionProfileService.GetAllSubmissionProfiles(false);
            return View(profiles);
        }
    }
}
