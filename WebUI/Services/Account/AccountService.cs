using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;
using WebUI.Models.common;
using WebUI.Models.DTOs.Account;
using WebUI.Services.common;

namespace WebUI.Services.Account
{
    public class AccountService : ProxyService, IAccountService
    {
        public AccountService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
            : base(httpClientFactory, configuration) { }

        public async Task<ApiResponse<SignInResponsetDto>> SignIn(SignInRequestDto request, CancellationToken cancellationToken = default)
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await client.PostAsync("/api/Account/signin", requestContent, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new BadHttpRequestException("HTTP_CLIENT");

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<SignInResponsetDto>>(content)!;

            if (!apiResponse.IsSuccess)
                throw new BadHttpRequestException("HTTP_CLIENT");

            return apiResponse;
        }
    }
}
