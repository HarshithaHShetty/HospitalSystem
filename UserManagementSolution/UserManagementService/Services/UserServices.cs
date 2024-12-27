using System.Security.Cryptography;
using System.Text;
using UserManagementService.Interfaces;
using UserManagementService.Models.DTOs;
using UserManagementService.Models;
using System.Reflection.Metadata.Ecma335;

namespace UserManagementService.Services
{

    public class UserService : IUserService
    {
        private readonly IRepository<User,string> _repository;
       
        private readonly IRepository<Patient, int> _patientRepository;
        private readonly ILogger<UserService> _logger;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<User, string> repository,
            IRepository<Patient, int> patientRepository,
        ILogger<UserService> logger, ITokenService tokenService)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _logger = logger;
            _tokenService = tokenService;
        }
        public async Task<UserResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            var user = await _repository.Get(loginRequest.Email);
            if (user == null)
            {
                _logger.LogCritical("User login attempt failed, Invalid username");
                throw new Exception("User not found");
            }
            HMACSHA256 hmac = new HMACSHA256(user.Key);
            var password = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequest.Password));
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] != user.Password[i])
                {
                    _logger.LogWarning("User login attempt failed, Invalid password");
                    throw new Exception("Invalid password");
                }
            }
            var userResponse = new UserResponseDTO
            {
                Username = user.Name,
                Email = user.Email,
                Role = user.Role,
                Status = user.Status,
            };
            userResponse.Token = await _tokenService.GenerateToken(userResponse);
            return userResponse;
        }

        public async Task<UserResponseDTO> RegisterPatient(PatientRegisterRequestDTO userRequest)
        {
            HMACSHA256 hmac = new HMACSHA256();
            User user = new User();
            user.Email = userRequest.Email;
            user.Name = userRequest.Name;
            user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRequest.Password));
        
         
            user.Key = hmac.Key;
            var result = await _repository.Add(user);
           
            if (result == null)
            {
                _logger.LogWarning("User creation failed");
                throw new Exception("User not added");
            }
            bool AddDetails = await AddPatient(result.Id, userRequest);



            var userResponse = new UserResponseDTO
            {
                Username = user.Name,
                Email=user.Email,
                Role = user.Role,
                Status = user.Status,
            };
            userResponse.Token = await _tokenService.GenerateToken(userResponse);
            return userResponse;
        }

        private async Task<bool> AddPatient(int UserId,PatientRegisterRequestDTO userRequest)
        {
            Patient patient = new Patient();
            patient.UserId = UserId;    
            patient.Age = userRequest.Age;
            patient.Address = userRequest.Address;
            patient.PhoneNo = userRequest.PhoneNo;
          


         
           await _patientRepository.Add(patient);
            return true;
        }
      
    }
}