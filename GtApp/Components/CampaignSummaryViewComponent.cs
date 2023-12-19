using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace GtApp.Components
{
    public class CampaignSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CampaignSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                        .CampaignService
                        .GetAllCampaigns(false)
                        .Count()
                        .ToString();
        }
    }
}
