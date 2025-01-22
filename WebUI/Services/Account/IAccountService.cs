using WebUI.Models.common;
using WebUI.Models.DTOs.Account;

namespace WebUI.Services.Account
{
    public interface IAccountService
    {
        Task<ApiResponse<AuthentificationResponsetDto>> SignInAsync(AuthentificationRequestDto request, CancellationToken cancellationToken = default);
        Task<ApiResponse<AuthentificationResponsetDto>> RefreshTokenAsync(RefreshTokenRequestDto request, CancellationToken cancellationToken = default);
        Task<ApiResponse<AuthentificationResponsetDto>> SignUp(SignUpRequestDto request, CancellationToken cancellationToken = default);
    }
}
