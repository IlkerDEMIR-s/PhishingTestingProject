namespace Entities.RequestParameters
{
    public class CampaignRequestParameters : RequestParameters
    {
        public string? campaignNameSearchTerm { get; set; }
        public int? emailTemplateId { get; set; }
        public int? summissionProfileId { get; set; }
    }
}
