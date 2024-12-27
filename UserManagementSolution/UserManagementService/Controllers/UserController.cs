using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagementService.Filters;
using UserManagementService.Interfaces;
using UserManagementService.Models.DTOs;

namespace UserManagementService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;

        public UserController(IUserService userService, IAdminService adminService)
        {
            _userService = userService;
            _adminService = adminService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDTO>> Login(LoginRequestDTO loginRequest)
        {
            var user = await _userService.Login(loginRequest);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDTO>> Register(PatientRegisterRequestDTO registerRequest)
        {
            var user = await _userService.RegisterPatient(registerRequest);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
        [HttpPost("AddDoctor")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<UserResponseDTO>> AddDoctor(DoctorRegisterRequestDTO registerRequest)
        {
            var user = await _adminService.AddDoctor(registerRequest);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

    }
}