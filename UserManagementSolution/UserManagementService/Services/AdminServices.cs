using System.Security.Cryptography;
using System.Text;
using UserManagementService.Interfaces;
using UserManagementService.Models.DTOs;
using UserManagementService.Models;
using UserManagementService.Repositories;
using UserManagementService.Services;

namespace UserManagementService.Services
{

    public class AdminService : IAdminService
    {
        private readonly IRepository<User, string> _repository;
        private readonly IRepository<Doctor, int> _doctorRepository;
   
        private readonly ILogger<UserService> _logger;
        private readonly ITokenService _tokenService;

        public AdminService(IRepository<User, string> repository, IRepository<Doctor, int> doctorRepository,
                            ILogger<UserService> logger,
                            ITokenService tokenService)
        {
            _repository = repository;
            _doctorRepository = doctorRepository;
            _logger = logger;
            _tokenService = tokenService;
        }
        public async Task<UserResponseDTO> AddDoctor(DoctorRegisterRequestDTO userRequest)
        {
            HMACSHA256 hmac = new HMACSHA256();
            User user = new User();
            user.Email = userRequest.Email;
            user.Name = userRequest.Name;
            user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRequest.Password));
            user.Role = Role.Doctor;
         
            user.Key = hmac.Key;
            var result = await _repository.Add(user);
           
            if (result == null)
            {
                _logger.LogWarning("User creation failed");
                throw new Exception("User not added");
            }
            bool AddDetails = await AddDoctor(result.Id, userRequest);



            var userResponse = new UserResponseDTO
            {
             Username = user.Name,
             Role = user.Role,
             Status = user.Status,
            };
            userResponse.Token = await _tokenService.GenerateToken(userResponse);
            return userResponse;
            }

        private async Task<bool> AddDoctor(int UserId, DoctorRegisterRequestDTO userRequest)
         {
            Doctor doctor = new Doctor();
            doctor.UserId = UserId;
            doctor.LicenseNumber = userRequest.LicenseNumber;
            doctor.Designation = userRequest.Designation;
            doctor.Age = userRequest.Age;
            doctor.Address = userRequest.Address;
            doctor.PhoneNo = userRequest.PhoneNo;




            await _doctorRepository.Add(doctor);
            return true;
            }
      
    }
}