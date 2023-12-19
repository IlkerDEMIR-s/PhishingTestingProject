using Entities.RequestParameters;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICampaignRepository : IRepositoryBase<Campaign>
    {
        IQueryable<Campaign> GetAllCampaigns(bool trackChanges);
        IQueryable<Campaign> GetAllCampaignsWithDetails(CampaignRequestParameters p);
        Campaign? GetOneCampaign(int id, bool trackChanges);
        void CreateOneCampaign(Campaign campaign);
        void UpdateOneCampaign(Campaign entity);
        void DeleteOneCampaign(Campaign campaign);
    }
}
