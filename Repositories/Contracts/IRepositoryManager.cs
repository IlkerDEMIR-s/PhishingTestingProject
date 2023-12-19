namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICampaignRepository Campaign { get; }
        ISubmissionProfileRepository SubmissionProfile { get; }
        IEmailTemplateRepository EmailTemplate { get; }
        ISocialMediaLoginRepository SocialMediaLogin { get; }
        IEmailLogRepository EmailLog { get; }

        void Save();
    }
}