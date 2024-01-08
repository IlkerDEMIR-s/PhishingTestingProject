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
    public class SubmissionProfileManager : ISubmissionProfileService
    {
        private readonly IRepositoryManager _manager;

        public SubmissionProfileManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateSubmissionProfile(SubmissionProfile submissionProfile)
        {
            _manager.SubmissionProfile.Create(submissionProfile);
            _manager.Save();
        }   

        public IEnumerable<SubmissionProfile> GetAllSubmissionProfiles(bool trackChanges)
        {
            return _manager.SubmissionProfile.GetAllSubmissionProfiles(trackChanges);
        }

        public SubmissionProfile? GetOneSubmissionProfile(int id, bool trackChanges)
        {
            var submissionProfile = _manager.SubmissionProfile.GetOneSubmissionProfile(id, trackChanges);
            if (submissionProfile == null)
            {
                throw new Exception("SubmissionProfile not found");
            }
            return submissionProfile;
            
        }

        public void UpdateOneSubmissionProfile(SubmissionProfile submissionProfile)
        {
            var entity = _manager.SubmissionProfile.GetOneSubmissionProfile((int)submissionProfile.SubmissionProfileId, true);
            entity.SubmissionProfileName = submissionProfile.SubmissionProfileName;
            entity.FromMail = submissionProfile.FromMail;
            entity.ToMail = submissionProfile.ToMail;

            _manager.Save();
        }

        public void DeleteOneSubmissionProfile(int id)
        {
            var submissionProfile = GetOneSubmissionProfile(id, true);
            if (submissionProfile is not null)  
            {
              _manager.SubmissionProfile.DeleteOneSubmissionProfile(submissionProfile);       
              _manager.Save();
            }
        }

        public SubmissionProfile? GetOneSubmissionProfileByToMail(string toMail, bool trackChanges)
        {
            var submissionProfile = _manager.SubmissionProfile.GetOneSubmissionProfileByToMail(toMail, trackChanges);
            if (submissionProfile == null)
            {
                throw new Exception("SubmissionProfile not found");
            }
            return submissionProfile;
        }
    }
}
