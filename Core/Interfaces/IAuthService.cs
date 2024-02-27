using Asp.Net_E_Commerce.Core.Dtos;
using Asp.Net_E_Commerce.Core.Entities;

namespace Asp.Net_E_Commerce.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthServiceResponseDto> SeedRoleAsync();
        Task<AuthServiceResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto);
        Task<AuthServiceResponseDto> MakeAdminAsync(UpdatePermissionDto updatePermissionDto);
        Task<AuthServiceResponseDto> MakeOwnerAsync(UpdatePermissionDto updatePermissionDto);
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task<AuthServiceResponseDto> DeleteUserByIdAsync(string userId);
    }
}