using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ISubmissionProfileRepository _submissionProfileRepository;
        private readonly IEmailTemplateRepository _emailTepmlateRepository;
        private readonly ISocialMediaLoginRepository _smLoginRepository;
        private readonly IEmailLogRepository _emailLogRepository;


        public RepositoryManager(RepositoryContext repositoryContext,
            ICampaignRepository campaignRepository,
            ISubmissionProfileRepository submissionProfileRepository,
            IEmailTemplateRepository emailTepmlateRepository,
            ISocialMediaLoginRepository smLoginRepository,
            IEmailLogRepository emailLogRepository)
        {
            _context = repositoryContext;
            _campaignRepository = campaignRepository;
            _submissionProfileRepository = submissionProfileRepository;
            _emailTepmlateRepository = emailTepmlateRepository;
            _smLoginRepository = smLoginRepository;
            _emailLogRepository = emailLogRepository;
        }

       public ICampaignRepository Campaign => _campaignRepository;
        public ISubmissionProfileRepository SubmissionProfile => _submissionProfileRepository;
        public IEmailTemplateRepository EmailTemplate => _emailTepmlateRepository;

        public ISocialMediaLoginRepository SocialMediaLogin => _smLoginRepository;
        public IEmailLogRepository EmailLog => _emailLogRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}