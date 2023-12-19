using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISocialMediaLoginService
    {
        IEnumerable<SocialMediaLogin> GetAllSocialMediaLogins(bool trackChanges);
        SocialMediaLogin? GetOneSocialMediaLogin(int id, bool trackChanges);
        void CreateSocialMediaLogin(SocialMediaLogin smLogin);
        void UpdateOneSocialMediaLogin(SocialMediaLogin smLogin);
        void DeleteOneSocialMediaLogin(int id);

    }
}
