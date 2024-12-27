using UserManagementService.Models.DTOs;

namespace UserManagementService.Interfaces
{
    public interface IUserService
    {
       
            public Task<UserResponseDTO> Login(LoginRequestDTO loginRequest);
            public Task<UserResponseDTO> RegisterPatient(PatientRegisterRequestDTO userRequest);
     


    }
}
