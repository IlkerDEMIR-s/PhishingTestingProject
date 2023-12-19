using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Components
{
    public class SubmissionProfileSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public SubmissionProfileSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                        .SubmissionProfileService
                        .GetAllSubmissionProfiles(false)
                        .Count()
                        .ToString();
        }
    }
}
