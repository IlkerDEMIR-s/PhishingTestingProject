using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Components
{
    public class EmailSendSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        
        public EmailSendSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                        .EmailLogService
                        .GetAllEmailLogs(false)
                        .Where(c => c.InteractionType == "send")
                        .Count()
                        .ToString();
        }
    }
}
