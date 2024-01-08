using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Components
{
    public class EmailTotalClickedSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public EmailTotalClickedSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                        .EmailLogService
                        .GetAllEmailLogs(false)
                        .Where(c => c.InteractionType == "clicked")
                        .Count()
                        .ToString();
        }
    }
}
