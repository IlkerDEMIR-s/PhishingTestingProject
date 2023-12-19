using Entitites.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmailTemplateRepository : RepositoryBase<EmailTemplate> , IEmailTemplateRepository
    {
        public EmailTemplateRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneEmailTemplate(EmailTemplate emailTemplate) => Create(emailTemplate);

        public void DeleteOneEmailTemplate(EmailTemplate emailTemplate) => Remove(emailTemplate);

        public void DeleteEmailTemplates(EmailTemplate emailTemplate) => Remove(emailTemplate);

        public EmailTemplate? GetOneEmailTemplate(int id, bool trackChanges)
        {
            return FindByCondition(p => p.EmailTemplateId.Equals(id), trackChanges);
        }

        public IQueryable<EmailTemplate> GetAllEmailTemplates(bool trackChanges) => FindAll(trackChanges);

        public void UpdateOneEmailTemplate(EmailTemplate entity) => Update(entity);
    }
}
