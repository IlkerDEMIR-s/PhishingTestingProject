using Entities.RequestParameters;
using Entitites.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CampaignManager : ICampaignService
    {
        private readonly IRepositoryManager _manager;

        public CampaignManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateCampaign(Campaign campaign)
        {
            _manager.Campaign.Create(campaign);
            _manager.Save();
        }   

        public IEnumerable<Campaign> GetAllCampaigns(bool trackChanges)
        {
            return _manager.Campaign.GetAllCampaigns(trackChanges);
        }

        public Campaign? GetOneCampaign(int id, bool trackChanges)
        {
            var campaign = _manager.Campaign.GetOneCampaign(id, trackChanges);
            if (campaign == null)
            {
                throw new Exception("Campaign not found");
            }
            return campaign;
            
        }

        public void UpdateOneCampaign(Campaign campaign)
        {
            var entity = _manager.Campaign.GetOneCampaign((int)campaign.CampaignId, true);
            entity.CampaignName = campaign.CampaignName;
            entity.SubmissionProfileId = campaign.SubmissionProfileId;
            entity.EmailTemplateId = campaign.EmailTemplateId;

            _manager.Save();
        }

        public void DeleteOneCampaign(int id)
        {
            var campaign = GetOneCampaign(id, true);
            if (campaign is not null)
            {
              _manager.Campaign.DeleteOneCampaign(campaign);       
              _manager.Save();
            }
        }

        public IQueryable<Campaign> GetAllCampaignsWithDetails(CampaignRequestParameters p)
        {
            return _manager.Campaign.GetAllCampaignsWithDetails(p);
        }
    }
}
