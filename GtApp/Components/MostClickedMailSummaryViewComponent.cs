using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Contracts;

namespace GtApp.Components
{
    public class MostClickedMailSummaryViewComponent : ViewComponent
    {
        private readonly RepositoryContext _context;
        string emailContent;

        public MostClickedMailSummaryViewComponent(RepositoryContext context)
        {
            _context = context;
        }

        public string Invoke()
        {
            var mostClickedEmail = _context.EmailLog
                .Where(c => c.InteractionType == "clicked")
                .GroupBy(c => c.UniqueIdentifier)
                .OrderByDescending(g => g.Count())
                .Select(g => g.FirstOrDefault())
                .FirstOrDefault();

            if (mostClickedEmail != null)
            {
                emailContent = _context.Campaign
                    .Where(c => c.CampaignId == mostClickedEmail.CampaignId)
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
