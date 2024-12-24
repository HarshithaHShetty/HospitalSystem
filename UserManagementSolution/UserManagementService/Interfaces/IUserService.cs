using UserManagementService.Models.DTOs;

namespace UserManagementService.Interfaces
{
    public interface IUserService
    {
       
            public Task<UserResponseDTO> Login(LoginRequestDTO loginRequest);
            public Task<UserResponseDTO> Register(UserRegisterRequestDTO userRequest);
        public Task<UserUpdateDTO> PatientUpdate(UserUpdateDTO updateRequest);


    }
}
