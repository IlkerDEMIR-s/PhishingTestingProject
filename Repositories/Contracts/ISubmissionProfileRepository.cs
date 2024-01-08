using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ISubmissionProfileRepository : IRepositoryBase<SubmissionProfile>
    {
        IQueryable<SubmissionProfile> GetAllSubmissionProfiles(bool trackChanges);
        SubmissionProfile? GetOneSubmissionProfile(int id, bool trackChanges);
        SubmissionProfile? GetOneSubmissionProfileByToMail(string toMail, bool trackChanges);
        void CreateOneSubmissionProfile(SubmissionProfile submissionProfile);
        void UpdateOneSubmissionProfile(SubmissionProfile entity);
        void DeleteOneSubmissionProfile(SubmissionProfile submissionProfile);
    }
}
