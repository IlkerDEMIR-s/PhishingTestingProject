using Entitites.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SubmissionProfileRepository : RepositoryBase<SubmissionProfile>, ISubmissionProfileRepository
    {
        public SubmissionProfileRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneSubmissionProfile(SubmissionProfile submissionProfile) => Create(submissionProfile);

        public void DeleteOneSubmissionProfile(SubmissionProfile submissionProfile) => Remove(submissionProfile);

        public void DeleteSubmissionProfiles(SubmissionProfile submissionProfile) => Remove(submissionProfile);

        public SubmissionProfile? GetOneSubmissionProfile(int id, bool trackChanges)
        {
            return FindByCondition(p => p.SubmissionProfileId.Equals(id), trackChanges);
        }

        public IQueryable<SubmissionProfile> GetAllSubmissionProfiles(bool trackChanges) => FindAll(trackChanges);

        public void UpdateOneSubmissionProfile(SubmissionProfile entity) => Update(entity);

        public SubmissionProfile? GetOneSubmissionProfileByToMail(string toMail, bool trackChanges)
        {
            return FindByCondition(p => p.ToMail.Contains(toMail), trackChanges);
        }
    }
}
