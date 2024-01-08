using Entities.RequestParameters;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IEmailLogService
    {
        IEnumerable<EmailLog> GetAllEmailLogs(bool trackChanges);

        EmailLog? GetOneEmailLog(int id, bool trackChanges);

        void CreateEmailLog(EmailLog emailClickLog);

        void UpdateOneEmailLog(EmailLog emailClickLog);

        void DeleteOneEmailLog(int id);
    }
}