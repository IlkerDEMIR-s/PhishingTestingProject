using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace GtApp.Components
{
    public class MostUsersSignInSummaryViewComponent : ViewComponent
    {
        private readonly RepositoryContext _context;
        string emailContent;

        public MostUsersSignInSummaryViewComponent(RepositoryContext context)
        {
            _context = context;
        }

        public string Invoke()
        {
            var mostSendEmail = _context.EmailLog
                .Where(c => c.InteractionType == "submitted")
                .GroupBy(c => c.CampaignId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.FirstOrDefault())
                .FirstOrDefault();

            if (mostSendEmail != null)
            {
                emailContent = _context.Campaign
                    .Where(c => c.CampaignId == mostSendEmail.CampaignId)
                .Join(
                        _context.EmailTemplate,
                        campaign => campaign.EmailTemplateId,
                        template => template.EmailTemplateId,
                        (campaign, template) => template.EmailContent
                    )
                    .FirstOrDefault().ToString();
            }

            return emailContent;
        }
    }
}
