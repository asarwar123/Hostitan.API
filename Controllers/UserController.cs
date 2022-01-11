using Hostitan.API.DTO.Users;
using Hostitan.API.Services;
using Hostitan_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hostitan.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public UserController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("User is running.");
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(AddUserDTO user)
        {
            ServiceResponse<int> response = await _authRepository.Register(user);   

            if(!response.success)
            {
                return BadRequest(response);
            }
            else
                return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginUserDTO user)
        {
            ServiceResponse<string> response = await _authRepository.Login(user.userName,user.password);   

            if(!response.success)
            {
                return BadRequest(response);
            }
            else
                return Ok(response);
        }
    }
}