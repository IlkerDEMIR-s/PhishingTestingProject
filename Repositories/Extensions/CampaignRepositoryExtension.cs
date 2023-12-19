using Entitites.Models;

namespace Repositories.Extensions
{
    public static class CampaignRepositoryExtension
    {

        public static IQueryable<Campaign> FilterByEmailTemplateId(this IQueryable<Campaign> campaigns,
                       int? emailTemplateId)
        {
            if (emailTemplateId == null)
            {
                return campaigns;
            }
            else
            {
                return campaigns.Where(p => p.EmailTemplateId == emailTemplateId);
            }

        }
        public static IQueryable<Campaign> FilterCampaignsBySubmissionProfileId (this IQueryable<Campaign> campaigns,
                               int? summissionProfileId)
        {
            if (summissionProfileId == null)
            {
                return campaigns;
            }
            else
            {
                return campaigns.Where(p => p.SubmissionProfileId == summissionProfileId);
            }

        }

        public static IQueryable<Campaign> FilterCampaignsByCampaignName (this IQueryable<Campaign> campaigns,
                    string? campaignNameSearchTerm)
        {
            if (string.IsNullOrWhiteSpace(campaignNameSearchTerm))
            {
                return campaigns;
            }
            else
            {
                return campaigns.Where(p => p.CampaignName.ToLower().Contains(campaignNameSearchTerm.Trim().ToLower()));
            }

        }



    }
}
