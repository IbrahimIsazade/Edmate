using WebUI.Models.common;
using WebUI.Models.DTOs.Account;
using WebUI.Services.common;

namespace WebUI.Services.Account
{
    public class AccountService : ProxyService, IAccountService
    {
        public AccountService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
            : base(httpClientFactory, configuration) { }

        public Task<ApiResponse<AuthentificationResponsetDto>> SignInAsync(AuthentificationRequestDto request, CancellationToken cancellationToken = default)
            => base.PostAsync<AuthentificationRequestDto, ApiResponse<AuthentificationResponsetDto>>("/api/Account/signin", request, cancellationToken);

        public Task<ApiResponse<AuthentificationResponsetDto>> RefreshTokenAsync(RefreshTokenRequestDto request, CancellationToken cancellationToken = default)
            => base.PostAsync<RefreshTokenRequestDto, ApiResponse<AuthentificationResponsetDto>>("/api/Account/refresh-token", request, cancellationToken);
        
        public Task<ApiResponse<AuthentificationResponsetDto>> SignUp(SignUpRequestDto request, CancellationToken cancellationToken = default)
            => base.PostAsync<SignUpRequestDto, ApiResponse<AuthentificationResponsetDto>>("/api/Account/signup", request, cancellationToken);
    }
}
