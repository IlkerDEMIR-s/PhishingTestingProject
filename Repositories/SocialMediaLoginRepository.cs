using Entitites.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SocialMediaLoginRepository : RepositoryBase<SocialMediaLogin>, ISocialMediaLoginRepository
    {
        public SocialMediaLoginRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneSocialMediaLogin(SocialMediaLogin smLogin) => Create(smLogin);

        public void DeleteOneSocialMediaLogin(SocialMediaLogin smLogin) => Remove(smLogin);

        public void DeleteSocialMediaLogins(SocialMediaLogin smLogin) => Remove(smLogin);

        public SocialMediaLogin? GetOneSocialMediaLogin(int id, bool trackChanges)
        {
            return FindByCondition(p => p.LoginId.Equals(id), trackChanges);
        }

        public IQueryable<SocialMediaLogin> GetAllSocialMediaLogins(bool trackChanges) => FindAll(trackChanges);

        public void UpdateOneSocialMediaLogin(SocialMediaLogin entity) => Update(entity);

    }
}
