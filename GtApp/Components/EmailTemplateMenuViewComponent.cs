using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Components
{
    public class EmailTemplateMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public EmailTemplateMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var emailTemplates = _manager.EmailTemplateService.GetAllEmailTemplates(false);
            return View(emailTemplates);
        }
    }
}
