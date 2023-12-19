using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ISocialMediaLoginRepository : IRepositoryBase<SocialMediaLogin>
    {
        IQueryable<SocialMediaLogin> GetAllSocialMediaLogins(bool trackChanges);
        SocialMediaLogin? GetOneSocialMediaLogin(int id, bool trackChanges);
        void CreateOneSocialMediaLogin(SocialMediaLogin smLogin);
        void UpdateOneSocialMediaLogin(SocialMediaLogin entity);
        void DeleteOneSocialMediaLogin(SocialMediaLogin smLogin);
    }
}
