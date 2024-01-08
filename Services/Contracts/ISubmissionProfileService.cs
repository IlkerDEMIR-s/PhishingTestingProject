using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISubmissionProfileService
    {
        IEnumerable<SubmissionProfile> GetAllSubmissionProfiles(bool trackChanges);

        SubmissionProfile? GetOneSubmissionProfile(int id, bool trackChanges);

        SubmissionProfile? GetOneSubmissionProfileByToMail(string toMail, bool trackChanges);

        void CreateSubmissionProfile(SubmissionProfile submissionProfile);

        void UpdateOneSubmissionProfile(SubmissionProfile submissionProfile);

        void DeleteOneSubmissionProfile(int id);
    }
}
