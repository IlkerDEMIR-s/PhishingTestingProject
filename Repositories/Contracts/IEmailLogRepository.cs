using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IEmailLogRepository : IRepositoryBase<EmailLog>
    {
        IQueryable<EmailLog> GetAllEmailLogs(bool trackChanges);
        EmailLog? GetOneEmailLog(int id, bool trackChanges);
        void CreateOneEmailLog(EmailLog emailClickLog);
        void UpdateOneEmailLog(EmailLog entity);
        void DeleteOneEmailLog(EmailLog emailClickLog);
    }
}
