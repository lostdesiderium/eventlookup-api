using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EventLookup.Domain.Models;
using EventLookup.Domain.Services;
using EventLookup.Domain.DTOs.User;
using AutoMapper;

using EventLookup.Services;
using Microsoft.AspNetCore.Authorization;

namespace EventLookup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersList()
        {
            var users = await _userService.GetUsersList();
            if (users != null)
                return Ok(users);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user != null)
                return Ok(user);
            return NoContent();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var isSuccessful = await _userService.UpdateUser(user, getTokenFromHeader());
            var result = "{ \"Success\" : " + isSuccessful +" }";
            return Ok(result);
        }

        [HttpPost]
        [Route("mark-user-event")]
        public async Task<IActionResult> MarkUserEvent(UserEvent userEvent)
        {
            var isSuccessful = await _userService.MarkUserEvent(userEvent);
            var result = "{ \"Success\" : " + isSuccessful + " }";
            return Ok(result);
        }

        [HttpPost]
        [Route("remove-event")]
        public async Task<IActionResult> RemoveUserEvent(UserEventDTO userEventDTO)
        {
            var isSuccessful = await _userService.RemoveUserEvent(userEventDTO.UserId, userEventDTO.EventId);
            var result = "{ \"Success\" : " + isSuccessful + " }";
            return Ok(result);
        }

        [HttpPost]
        [Route("upload-image")]
        public async Task<IActionResult> UploadUserImage(User user)
        {
            var isSuccessful = await _userService.UploadUserImage(user, getTokenFromHeader());
            return Ok();
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO user)
        {
            try {            
                var isSuccessful = await _userService.ChangePassword(user);
                var result = "{ \"Success\" : " + isSuccessful + " }";
                return Ok(result);
            }
            catch(Exception e)
            {
                BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("token-login")]
        public async Task<IActionResult> UserLoginWithToken()
        {
            string accessTokenHeader = HttpContext.Request.Headers["Authorization"];
            var token = accessTokenHeader.Substring("Bearer ".Length).Trim();
            
            AuthenticationUser loginResult = await _userService.UserLoginWithToken(token);
            return Ok(loginResult);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin(User user)
        {
            AuthenticationUser loginResult = await _userService.UserLogin(user);
            return Ok(loginResult);
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> UserRegister(User user)
        {
            AuthenticationUser registerResult = await _userService.UserRegister(user);
            return Ok(registerResult);
        }

        private string getTokenFromHeader()
        {
            string accessTokenHeader = HttpContext.Request.Headers["Authorization"];
            return accessTokenHeader.Substring("Bearer ".Length).Trim();
        }
    }
}