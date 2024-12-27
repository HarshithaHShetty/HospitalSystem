using UserManagementService.Models.DTOs;

namespace UserManagementService.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserResponseDTO user);
    }
}
