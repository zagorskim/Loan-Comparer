//using Loans_Comparer.Migrations;
using Loans_Comparer.Entities.Enums;
using Loans_Comparer.Migrations;
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
    public class LocalBankHandler : IBankHandler
    {
        public BankNames BankName => BankNames.LocalBank;
        private HttpClient _httpClient { get; set; }
        private readonly ExternalServicesConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public LocalBankHandler(IOptions<ExternalServicesConfiguration> config, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _config = config.Value;

            SetHttpClient();
        }


        public List<OfferLocalBankGetResponse> OffersShowAll()
        {
            var url = $"{_config.LocalCompanyApi}/Offer/All";
            var response = _httpClient.GetAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                UpdateBearer();
                response = _httpClient.GetAsync(url).Result;
            }

            var offerLocalResponse = JsonConvert.DeserializeObject<List<OfferLocalBankGetResponse>>(response.Content.ReadAsStringAsync().Result);
            return offerLocalResponse;
        }

        public List<InquiryLocalBankDto> InquiresShowAll()
        {
            var url = $"{_config.LocalCompanyApi}/api/Inquire/All";
            var response = _httpClient.GetAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                UpdateBearer();
                response = _httpClient.GetAsync(url).Result;
            }

            var offerLocalResponse = JsonConvert.DeserializeObject<List<InquiryLocalBankDto>>(response.Content.ReadAsStringAsync().Result);
            return offerLocalResponse;
        }

        public string GetCreateInquiryUrl()
        {
            return $"{_config.LocalCompanyApi}/api/Inquire/";
        }

        public InquiryExternalPostResponseDto CreateInquiry(InquiryExternalPostRequestDto request)
        {
            var url = GetCreateInquiryUrl();
            double incomeLevel;
            var localRequest = new InquiryLocalBankPostRequestDto()
            {
                moneyAmount = request.value,
                installmentsNumber = request.installmentsNumber,
                firstName = request.personalData.FirstName,
                lastName = request.personalData.LastName,
                documentType = request.governmentDocument.typeId,
                documentId = request.governmentDocument.number,
                jobType = request.jobDetails.typeId,
                incomeLevel = Double.TryParse(request.jobDetails.description, out incomeLevel) ? incomeLevel : 1
            };
            var body = new StringContent(JsonConvert.SerializeObject(localRequest), Encoding.UTF8, "application/json");
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
            return $"{_config.LocalCompanyApi}/api/Inquire/{Guid.Parse(inqId)}";
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

            var inquiryLocalResponse = JsonConvert.DeserializeObject<InquiryOtherBankGetResponseDto>(response.Content.ReadAsStringAsync().Result);
            var inquiryResponse = new InquiryExternalGetResponseDto()
            {
                inquireId = inquiryLocalResponse.inquireId,
                createDate = inquiryLocalResponse.creationDate,
                offerId = inquiryLocalResponse.offerId,
                statusId = -1,
                statusDescription = "",

            };
            return inquiryResponse;
        }

        public string GetOfferUrl(string offerId)
        {
            return $"{_config.LocalCompanyApi}/Offer/{Guid.Parse(offerId)}";
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

            var offerLocalResponse = JsonConvert.DeserializeObject<OfferLocalBankGetResponse>(response.Content.ReadAsStringAsync().Result);
            var offerResponse = new OfferExternalGetResponseDto()
            {
                id = offerLocalResponse.id,
                percentage = offerLocalResponse.percentage,
                monthlyInstallment = offerLocalResponse.monthlyInstallment,
                requestedValue = offerLocalResponse.requesedValue,
                requestedPeriodInMonth = offerLocalResponse.requestedPeriodInMonth,
                statusId = offerLocalResponse.statusID,
                statusDescription = offerLocalResponse.statusDescription,
                inquireId = offerLocalResponse.inquireId,
                createDate = offerLocalResponse.createdDate,
                updateDate = offerLocalResponse.updatedDate,
                approvedBy = "",
                documentLink = offerLocalResponse.documentLink,
                documentLinkValidDate = offerLocalResponse.documentLinkValidDate
            };
            return offerResponse;
        }

        public string GetDocumentUploadUrl(string offerId)
        {
            return $"{_config.LocalCompanyApi}/Offer/{offerId}/document/upload";
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
            return $"{_config.LocalCompanyApi}/Offer/{offerId}/complete";
        }

        public HttpStatusCode CompleteOffer(string offerId)
        {
            var url = GetCompleteUrl(offerId);
            var response = _httpClient.PostAsync(url, null);
            return response.Result.StatusCode;
        }

        public string GetAcceptUrl(string offerId)
        {
            return $"{_config.LocalCompanyApi}/Offer/{offerId}/Accept";
        }

        public HttpStatusCode AcceptOffer(string offerId)
        {
            var url = GetAcceptUrl(offerId);
            var response = _httpClient.PostAsync(url, null);
            return response.Result.StatusCode;
        }

        public string GetRejectUrl(string offerId)
        {
            return $"{_config.LocalCompanyApi}/Offer/{offerId}/Reject";
        }

        public HttpStatusCode RejectOffer(string offerId)
        {
            var url = GetRejectUrl(offerId);
            var response = _httpClient.PostAsync(url, null);
            return response.Result.StatusCode;
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
                {"client_id", "780e643f-b7a1-40a5-839f-81af10307d7e" },
                {"client_secret", "4N38Q~iRNsFfIvk5SwutWnT9CZ2X_L1rVdEGYdav" },
                {"scope", "https://bankapi.onmicrosoft.com/8a938b48-5148-4170-ac07-dc4c631e7589/.default"}
            };

            var tokenResponse = _httpClient.PostAsync("https://bankapi.b2clogin.com/bankapi.onmicrosoft.com/B2C_1_signupsignin1/oauth2/v2.0/token", new FormUrlEncodedContent(form));
            var jsonContent = tokenResponse.Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Token>(jsonContent).AccessToken;
        }
    }
}
