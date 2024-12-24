using UserManagementService.Models.DTOs;

namespace UserManagementService.Interfaces
{
    public interface IAdminService
    {
       
        public Task<UserResponseDTO> RegisterDoctor(DoctorRegisterRequestDTO doctorRequest);
        public Task<int> DeleteDoctor(int DoctorId);
    }
}
