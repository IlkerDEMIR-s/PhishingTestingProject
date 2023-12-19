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
    public class EmailTemplateManager : IEmailTemplateService
    {
        private readonly IRepositoryManager _manager;

        public EmailTemplateManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateEmailTemplate(EmailTemplate emailTemplate)
        {
            _manager.EmailTemplate.Create(emailTemplate);
            _manager.Save();
        }

        public IEnumerable<EmailTemplate> GetAllEmailTemplates(bool trackChanges)
        {
            return _manager.EmailTemplate.GetAllEmailTemplates(trackChanges);
        }

        public EmailTemplate? GetOneEmailTemplate(int id, bool trackChanges)
        {
            var emailTemplate = _manager.EmailTemplate.GetOneEmailTemplate(id, trackChanges);
            if (emailTemplate == null)
            {
                throw new Exception("EmailTemplate not found");
            }
            return emailTemplate;
            
        }

        public void UpdateOneEmailTemplate(EmailTemplate emailTemplate)
        {
            var entity = _manager.EmailTemplate.GetOneEmailTemplate(emailTemplate.EmailTemplateId, true);
            entity.EmailTemplateName = emailTemplate.EmailTemplateName;
            entity.EmailSubject = emailTemplate.EmailSubject;
            entity.EmailContent = emailTemplate.EmailContent;
            entity.LandingPageUrl = emailTemplate.LandingPageUrl;

            _manager.Save();
        }

        public void DeleteOneEmailTemplate(int id)
        {
            var emailTemplate = GetOneEmailTemplate(id, true);
            if (emailTemplate is not null)
            {
              _manager.EmailTemplate.DeleteOneEmailTemplate(emailTemplate);       
              _manager.Save();
            }
        }

    }
}
