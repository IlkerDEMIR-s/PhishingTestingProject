using Entities.RequestParameters;
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
    public class EmailLogManager : IEmailLogService
    {
        private readonly IRepositoryManager _manager;

        public EmailLogManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateEmailLog(EmailLog emailClickLog)
        {
            _manager.EmailLog.Create(emailClickLog);
            _manager.Save();
        }

        public IEnumerable<EmailLog> GetAllEmailLogs(bool trackChanges)
        {
            return _manager.EmailLog.GetAllEmailLogs(trackChanges);
        }

        public EmailLog? GetOneEmailLog(int id, bool trackChanges)
        {
            var emailClickLog = _manager.EmailLog.GetOneEmailLog(id, trackChanges);
            if (emailClickLog == null)
            {
                throw new Exception("EmailClickLog not found");
            }
            return emailClickLog;
            
        }

        public void UpdateOneEmailLog(EmailLog emailClickLog)
        {
            var entity = _manager.EmailLog.GetOneEmailLog((int)emailClickLog.EmailLogId, true);
            entity.CampaignId = emailClickLog.CampaignId;
            entity.ClickTimestamp = emailClickLog.ClickTimestamp;
                
            _manager.Save();
        }

        public void DeleteOneEmailLog(int id)
        {
            var emailClickLog = GetOneEmailLog(id, true);
            if (emailClickLog is not null)
            {
              _manager.EmailLog.DeleteOneEmailLog(emailClickLog);       
              _manager.Save();
            }
        }


    }
}
