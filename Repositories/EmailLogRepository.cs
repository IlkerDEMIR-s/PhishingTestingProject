using Entitites.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmailLogRepository : RepositoryBase<EmailLog>, IEmailLogRepository
    {
        public EmailLogRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneEmailLog(EmailLog emailClickLog) => Create(emailClickLog);

        public void DeleteOneEmailLog(EmailLog emailClickLog) => Remove(emailClickLog);

        public void DeleteEmailLogs(EmailLog emailClickLog) => Remove(emailClickLog);

        public EmailLog? GetOneEmailLog(int id, bool trackChanges)
        {
            return FindByCondition(p => p.EmailLogId.Equals(id), trackChanges);
        }

        public IQueryable<EmailLog> GetAllEmailLogs(bool trackChanges) => FindAll(trackChanges);

        public void UpdateOneEmailLog(EmailLog entity) => Update(entity);
    }
}
