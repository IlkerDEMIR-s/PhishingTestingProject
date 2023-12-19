using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Components
{
    public class EmailSubmittedSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        
        public EmailSubmittedSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                        .EmailLogService
                        .GetAllEmailLogs(false)
                        .Where(c => c.InteractionType == "submitted")
                        .Count()
                        .ToString();
        }
    }
}
