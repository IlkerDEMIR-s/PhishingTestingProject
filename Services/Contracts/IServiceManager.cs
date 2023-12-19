namespace Services.Contracts
{

   public interface IServiceManager
   {
       IAuthService AuthService { get; }
       ICampaignService CampaignService { get; }
       ISubmissionProfileService SubmissionProfileService { get; }
       IEmailTemplateService EmailTemplateService { get; }
       ISocialMediaLoginService SocialMediaLoginService { get; }
       IEmailLogService EmailLogService { get; }
    }


}