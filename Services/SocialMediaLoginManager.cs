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
    public class SocialMediaLoginManager : ISocialMediaLoginService
    {
        private readonly IRepositoryManager _manager;

        public SocialMediaLoginManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateSocialMediaLogin(SocialMediaLogin smLogin)
        {
            _manager.SocialMediaLogin.Create(smLogin);
            _manager.Save();
        }

        public IEnumerable<SocialMediaLogin> GetAllSocialMediaLogins(bool trackChanges)
        {
            return _manager.SocialMediaLogin.GetAllSocialMediaLogins(trackChanges);
        }

        public SocialMediaLogin? GetOneSocialMediaLogin(int id, bool trackChanges)
        {
            var instagramLogin = _manager.SocialMediaLogin.GetOneSocialMediaLogin(id, trackChanges);
            if (instagramLogin == null)
            {
                throw new Exception("InstagramLogin not found");
            }
            return instagramLogin;
            
        }

        public void UpdateOneSocialMediaLogin(SocialMediaLogin smLogin)
        {
            var entity = _manager.SocialMediaLogin.GetOneSocialMediaLogin((int)smLogin.LoginId, true);
            entity.UserTerm = smLogin.UserTerm;
            entity.Password = smLogin.Password;
            entity.LoginDate = smLogin.LoginDate;

        }

        public void DeleteOneSocialMediaLogin(int id)
        {
            var smLogin = GetOneSocialMediaLogin(id, true);
            if (smLogin is not null)
            {
              _manager.SocialMediaLogin.DeleteOneSocialMediaLogin(smLogin);       
              _manager.Save();
            }
        }
        

    }
}
