using UserManagementService.Models.DTOs;

namespace UserManagementService.Interfaces
{
    public interface IAdminService
    {
       
        public Task<UserResponseDTO> AddDoctor(DoctorRegisterRequestDTO doctorRequest);
       
    }
}
