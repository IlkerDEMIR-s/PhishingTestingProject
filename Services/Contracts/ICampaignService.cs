using Entities.RequestParameters;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICampaignService
    {
        IEnumerable<Campaign> GetAllCampaigns(bool trackChanges);

        IQueryable<Campaign> GetAllCampaignsWithDetails(CampaignRequestParameters p);

        Campaign? GetOneCampaign(int id, bool trackChanges);

        void CreateCampaign(Campaign campaign);

        void UpdateOneCampaign(Campaign campaign);

        void DeleteOneCampaign(int id);
    }
}
