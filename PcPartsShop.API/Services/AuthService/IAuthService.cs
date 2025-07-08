using PcPartsShop.API.DTOs.User;

namespace PcPartsShop.API.Services.AuthService
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }

}
