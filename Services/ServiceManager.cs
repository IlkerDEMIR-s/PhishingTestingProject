using Services.Contracts;


namespace Services
{

    public class ServiceManager : IServiceManager
    {
        private readonly IAuthService _authService;
        private readonly ICampaignService _campaignService;
        private readonly ISubmissionProfileService _submissionProfileService;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly ISocialMediaLoginService _smLoginService;
        private readonly IEmailLogService _emailLogService;

        public ServiceManager(IAuthService authService,
            ICampaignService campaignService,
            ISubmissionProfileService submissionProfileService,
            IEmailTemplateService emailTemplateService,
            ISocialMediaLoginService smLoginService,
            IEmailLogService emailLogService)
        {
            _authService = authService;
            _campaignService = campaignService;
            _submissionProfileService = submissionProfileService;
            _emailTemplateService = emailTemplateService;
            _smLoginService = smLoginService;
            _emailLogService = emailLogService;
        }

        public IAuthService AuthService => _authService;

        public ICampaignService CampaignService => _campaignService;

        public ISubmissionProfileService SubmissionProfileService => _submissionProfileService;

        public IEmailTemplateService EmailTemplateService => _emailTemplateService;

        public ISocialMediaLoginService SocialMediaLoginService => _smLoginService;

        public IEmailLogService EmailLogService => _emailLogService;

    }
}