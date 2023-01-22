using Loans_Comparer.Entities.Enums;
using Loans_Comparer.Requests;
using Loans_Comparer.Requests.ExternalApi;
using Loans_Comparer.Requests.ExternalApi.LocalBank;
using Loans_Comparer.Requests.ExternalApi.OtherBank;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Loans_Comparer.Utilities.BankHandlers
{
    public class OtherBankHandler : IBankHandler
    {
        public BankNames BankName => BankNames.OtherBank;
        private HttpClient _httpClient { get; set; }
        private readonly ExternalServicesConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public OtherBankHandler(IOptions<ExternalServicesConfiguration> config, IHttpClientFactory httpClientFactory)
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
            return $"{_config.OtherCompanyApi}/api/External_v2/Inquire";
        }

        public InquiryExternalPostResponseDto CreateInquiry(InquiryExternalPostRequestDto request)
        {
            var url = GetCreateInquiryUrl();
            double incomeLevel;
            var otherBankRequest = new InquiryOtherBankPostRequestDto()
            {
                moneyAmount = request.value,
                installmentsNumber = request.installmentsNumber,
                firstName = request.personalData.FirstName,
                lastName = request.personalData.LastName,
                documentType = request.governmentDocument.typeId,
                documentId = request.governmentDocument.number,
                jobType = request.jobDetails.typeId,
                incomeLevel = Double.TryParse(request.jobDetails.description, out incomeLevel) ? incomeLevel : 0 //Convert.ToDouble(request.jobDetails.description)
            };
            var body = new StringContent(JsonConvert.SerializeObject(otherBankRequest), Encoding.UTF8, "application/json");
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
            return $"{_config.OtherCompanyApi}/api/External_v2/Inquire/{Guid.Parse(inqId)}";
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

            var otherInquiryResponse = JsonConvert.DeserializeObject<InquiryOtherBankGetResponseDto>(response.Content.ReadAsStringAsync().Result);
            var inquiryResponse = new InquiryExternalGetResponseDto()
            {
                createDate = otherInquiryResponse.creationDate,
                inquireId = otherInquiryResponse.inquireId,
                statusId = -1,
                statusDescription = "",
                offerId = otherInquiryResponse.offerId
            };
            return inquiryResponse;
        }
        public string GetOfferUrl(string offerId)
        {
            return $"{_config.OtherCompanyApi}/api/External_v2/Offer/{Guid.Parse(offerId)}";
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

            var offerOtherResponse = JsonConvert.DeserializeObject<OfferOtherBankGetResponseDto>(response.Content.ReadAsStringAsync().Result);
            var offerResponse = new OfferExternalGetResponseDto()
            {
                id = offerOtherResponse.id,
                percentage = offerOtherResponse.percentage,
                monthlyInstallment = offerOtherResponse.monthlyInstallment,
                requestedValue = offerOtherResponse.requesedValue,
                requestedPeriodInMonth = offerOtherResponse.requestedPeriodInMonth,
                statusId = offerOtherResponse.statusId,
                statusDescription = offerOtherResponse.statusDescription,
                inquireId = offerOtherResponse.inquireId,
                createDate = offerOtherResponse.createDate,
                updateDate = offerOtherResponse.updateDate,
                approvedBy = "",
                documentLink = offerOtherResponse.documentLink,
                documentLinkValidDate = offerOtherResponse.documentLinkValidDate
            };
            return offerResponse;
        }

        public string GetDocumentUploadUrl(string offerId)
        {
            return $"{_config.OtherCompanyApi}/api/External_v2/Offer/{offerId}/document/upload";
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
            return $"{_config.OtherCompanyApi}/api/External_v2/Offer/{offerId}/complete";
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
                {"client_id", "5ea0eae2-7da5-4222-b7b2-820324d5f36d" },
                {"client_secret", "l2Z8Q~8V7bfvGQA_fuaymOrhP3vjy2tGkKLcmbO." },
                {"scope", "https://CreditComparer.onmicrosoft.com/08b8fb66-4b9f-493a-b3d2-53158caeb956/.default" }
            };

            var tokenResponse = _httpClient.PostAsync("https://CreditComparer.b2clogin.com/CreditComparer.onmicrosoft.com/B2C_1_susi/oauth2/v2.0/token", new FormUrlEncodedContent(form));
            var jsonContent = tokenResponse.Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Token>(jsonContent).AccessToken;
        }
    }
}
