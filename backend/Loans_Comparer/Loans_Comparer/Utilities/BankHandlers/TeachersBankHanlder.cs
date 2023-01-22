using Loans_Comparer.Entites;
using Loans_Comparer.Entities.Enums;
using Loans_Comparer.Requests.ExternalApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;
using Loans_Comparer.Requests;
using Loans_Comparer.Requests.ExternalApi.LocalBank;

namespace Loans_Comparer.Utilities.BankHandlers
{
    public class TeachersBankHanlder : IBankHandler
    {
        public BankNames BankName => BankNames.TeachersBank;
        private HttpClient _httpClient { get; set; }
        private readonly ExternalServicesConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public TeachersBankHanlder(IOptions<ExternalServicesConfiguration> config, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _config = config.Value;

            SetHttpClient();
        }


        public List<OfferLocalBankGetResponse> OffersShowAll()
        {
            return null;
        }
        public List<InquiryLocalBankDto> InquiresShowAll()
        {
            return null;
        }
        public string GetCreateInquiryUrl()
        {
            return $"{_config.TeachersCompanyApi}/api/v1/Inquire";
        }
        public InquiryExternalPostResponseDto CreateInquiry(InquiryExternalPostRequestDto request)
        {
            var url = GetCreateInquiryUrl();
            var body = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(url, body).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                UpdateBearer();
                response = _httpClient.PostAsync(url, body).Result;
            }

            var inquiryResponse = JsonConvert.DeserializeObject<InquiryExternalPostResponseDto>(response.Content.ReadAsStringAsync().Result);
            return inquiryResponse;
        }
        public string GetExistingInquiryUrl(string inqId)
        {
            return $"{_config.TeachersCompanyApi}/api/v1/Inquire/{inqId}";
        }
        public InquiryExternalGetResponseDto GetExistingInquiry(string inqId)
        {
            var url = GetExistingInquiryUrl(inqId);
            var response = _httpClient.GetAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                UpdateBearer();
                response = _httpClient.GetAsync(url).Result;
            }

            var inquiryResponse = JsonConvert.DeserializeObject<InquiryExternalGetResponseDto>(response.Content.ReadAsStringAsync().Result);
            return inquiryResponse;
        }
        public string GetOfferUrl(string offerId)
        {
            return $"{_config.TeachersCompanyApi}/api/v1/Offer/{offerId}";
        }
        public OfferExternalGetResponseDto GetExistingOffer(string offerId)
        {
            var url = GetOfferUrl(offerId);
            var response = _httpClient.GetAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                UpdateBearer();
                response = _httpClient.GetAsync(url).Result;
            }

            var offerResponse = JsonConvert.DeserializeObject<OfferExternalGetResponseDto>(response.Content.ReadAsStringAsync().Result);
            return offerResponse;
        }
        public string GetDocumentUploadUrl(string offerId)
        {
            return $"{_config.TeachersCompanyApi}/api/v1/Offer/{offerId}/document/upload";
        }
        public HttpStatusCode UploadDocument(string offerId, IFormFile fileData)
        {
            var url = GetDocumentUploadUrl(offerId);
            var multipartContent = new MultipartFormDataContent();

            multipartContent.Add(new StreamContent(fileData.OpenReadStream())
            {
                Headers =
                {
                    ContentLength = fileData.Length,
                    ContentType = new MediaTypeHeaderValue(fileData.ContentType),
                    ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "formFile", FileName = fileData.FileName }
                }
            });
            var response = _httpClient.PostAsync(url, multipartContent).Result;
            return response.StatusCode;
        }

        public string GetCompleteUrl(string offerId)
        {
            return $"{_config.TeachersCompanyApi}/api/v1/Offer/{offerId}/complete";
        }
        public HttpStatusCode CompleteOffer(string offerId)
        {
            var url = GetCompleteUrl(offerId);
            var response = _httpClient.PostAsync(url, null);
            return response.Result.StatusCode;
        }

        public string GetAcceptUrl(string offerId)
        {
            return null;
        }
        public HttpStatusCode AcceptOffer(string offerId)
        {
            return HttpStatusCode.MethodNotAllowed;
        }

        public string GetRejectUrl(string offerId)
        {
            return null;
        }
        public HttpStatusCode RejectOffer(string offerId)
        {
            return HttpStatusCode.MethodNotAllowed;
        }

        public void SetHttpClient(int timeout = 100)
        {
            var httpClient = _httpClientFactory.CreateClient("BankApiClient");
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            _httpClient = httpClient;
            UpdateBearer();
        }
        public void UpdateBearer()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());
        }
        public string GetToken()
        {
            var form = new Dictionary<string, string>
            {
                {"grant_type", "client_credentials" },
                {"client_id", "team2e" },
                {"client_secret", "F6708E57-54D8-4EE1-8318-0A7EBD6639FE" }
            };

            var tokenResponse = _httpClient.PostAsync("https://indentitymanager.snet.com.pl/connect/token", new FormUrlEncodedContent(form));
            var jsonContent = tokenResponse.Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Token>(jsonContent).AccessToken;
        }
    }
}
