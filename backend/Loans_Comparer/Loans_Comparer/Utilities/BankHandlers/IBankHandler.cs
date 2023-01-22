using Loans_Comparer.Entities.Enums;
using Loans_Comparer.Requests;
using Loans_Comparer.Requests.ExternalApi;
using Loans_Comparer.Requests.ExternalApi.LocalBank;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace Loans_Comparer.Utilities.BankHandlers
{
    public interface IBankHandler
    {
        BankNames BankName { get; }
        string GetCreateInquiryUrl();
        public InquiryExternalPostResponseDto CreateInquiry(InquiryExternalPostRequestDto request);
        string GetExistingInquiryUrl(string inqId);
        public InquiryExternalGetResponseDto GetExistingInquiry(string inqId);
        string GetOfferUrl(string offerId);
        public OfferExternalGetResponseDto GetExistingOffer(string offerId);
        public string GetDocumentUploadUrl(string offerId);
        public HttpStatusCode UploadDocument(string offerId, IFormFile fileData);
        public List<OfferLocalBankGetResponse> OffersShowAll();
        public List<InquiryLocalBankDto> InquiresShowAll();
        string GetCompleteUrl(string offerId);
        public HttpStatusCode CompleteOffer(string offerId);
        public string GetAcceptUrl(string offerId);
        public HttpStatusCode AcceptOffer(string offerId);
        public string GetRejectUrl(string offerId);
        public HttpStatusCode RejectOffer(string offerId);
    }
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
