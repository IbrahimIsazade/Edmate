using WebUI.Models.common;
using WebUI.Models.DTOs.Account;

namespace WebUI.Services.Account
{
    public interface IAccountService
    {
        Task<ApiResponse<SignInResponsetDto>> SignIn(SignInRequestDto request, CancellationToken cancellationToken = default);
    }
}
