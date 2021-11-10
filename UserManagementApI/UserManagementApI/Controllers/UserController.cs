using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementApI.Services.Interfaces;
//using UserManagementApI.Services.Interfaces;
using UserManagementApI.UserModels;

namespace UserManagementApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger<UserController> logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpPost]
        [Route("RegisterUser")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] UserModel model)
        {
            try
            {
                var result = await this.userService.RegisterUser(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);

            }

        }

        [HttpPost]
        [Route("BlockUser")]
        public async Task<IActionResult> BlockUser(ActivateUserModel model)
        {
            try
            {
                var result = await this.userService.BlockUser(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);

            }

        }
        [HttpPost]
        [Route("ActivateUser")]
        public async Task<IActionResult> ActivateUser(ActivateUserModel model)
        {
            try
            {
                var result = await this.userService.ActivateUser(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);

            }

        }
        [HttpGet]
        [Route("GetRolesById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRolesById([FromQuery] int userId)
        {
            try
            {
                var result = await this.userService.GetRolesById(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);

            }

        }
        [HttpGet]
        [Route("GetRolesByEmail")]
        public async Task<IActionResult> GetRolesByEmail([FromQuery] string email)
        {
            try
            {
                var result = await this.userService.GetRolesByEmail(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);

            }

        }
        

        [HttpPost]
        [Route("UpdateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel model)
        {
            try
            {
                var result = await this.userService.UpdateUser(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);

            }

        }

        [HttpGet]
        [Route("GetAllHospitalUsers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllHospitalUsers()
        {
            try
            {
                var result = await this.userService.GetAllHospitalUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);

            }
        }
        [HttpGet]
        [Route("GetUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                var result = await this.userService.GetUser(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);

            }
        }
        [HttpGet]
        [Route("GetAllRoles")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var result = await userService.GetAllRoles();
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);

            }
        }
        [HttpPost]
        [Route("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] LoginModel model)
        {
            //try
            //{
                var result = await userService.ForgotPassword(model.Email);
                return Ok(result);

            //}
            //catch (Exception ex)
            //{
            //    logger.Log(LogLevel.Error, ex, ex.Message);
            //    return BadRequest("Email not send");
            //}


        }

        [HttpPost]
        [Route("ChangePassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword([FromBody] LoginModel model)
        {
            try
            {
                var result = await userService.ChangePassword(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);

            }

        }
    }
}

