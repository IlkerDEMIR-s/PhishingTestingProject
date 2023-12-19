using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IEmailTemplateRepository : IRepositoryBase<EmailTemplate>
    {
        IQueryable<EmailTemplate> GetAllEmailTemplates(bool trackChanges);
        EmailTemplate? GetOneEmailTemplate(int id, bool trackChanges);
        void CreateOneEmailTemplate(EmailTemplate emailTemplate);
        void UpdateOneEmailTemplate(EmailTemplate entity);
        void DeleteOneEmailTemplate(EmailTemplate emailTemplate);
    }
}
