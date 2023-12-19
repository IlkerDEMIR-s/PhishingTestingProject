using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Components
{
    public class TemplateSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public TemplateSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                        .EmailTemplateService
                        .GetAllEmailTemplates(false)
                        .Count()
                        .ToString();
        }
    }
}
