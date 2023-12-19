using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IEmailTemplateService
    {
        IEnumerable<EmailTemplate> GetAllEmailTemplates(bool trackChanges);
        EmailTemplate? GetOneEmailTemplate(int id, bool trackChanges);
        void CreateEmailTemplate(EmailTemplate emailTemplate);
        void UpdateOneEmailTemplate(EmailTemplate emailTemplate);
        void DeleteOneEmailTemplate(int id);
    }
}
