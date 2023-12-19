using Entities.RequestParameters;
using Entitites.Models;
using Repositories.Contracts;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CampaignRepository : RepositoryBase<Campaign>, ICampaignRepository
    {
        public CampaignRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCampaign(Campaign campaign) => Create(campaign);

        public void DeleteOneCampaign(Campaign campaign) => Remove(campaign);

        public void DeleteCampaigns(Campaign campaign) => Remove(campaign);

        public Campaign? GetOneCampaign(int id, bool trackChanges)
        {
            return FindByCondition(p => p.CampaignId.Equals(id), trackChanges);
        }

        public IQueryable<Campaign> GetAllCampaigns(bool trackChanges) => FindAll(trackChanges);


        public void UpdateOneCampaign(Campaign entity) => Update(entity);

        public IQueryable<Campaign> GetAllCampaignsWithDetails(CampaignRequestParameters p)
        {
            return _context
                   .Campaign
                   .FilterByEmailTemplateId(p.emailTemplateId)
                   .FilterCampaignsBySubmissionProfileId(p.summissionProfileId)
                   .FilterCampaignsByCampaignName(p.campaignNameSearchTerm);
                   
        }
    }

}
