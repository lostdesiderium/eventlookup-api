using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using EventLookup.Domain.Services;
using EventLookup.Domain.Models;
using EventLookup.Domain.DTOs;
using EventLookup.Domain.DTOs.User;
using EventLookupBO.Domain;

namespace EventLookupBO.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        private string WebAPIPath = "http://localhost:19422/api/";
        UserState UserState = UserState.Instance;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
            
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public async Task OnPostAsync()
        {
            User user = new User();
            user.Email = Email;
            user.Password = Password;
            AuthenticationUser authenicatedUser = await _userService.UserLogin(user);
            if(authenicatedUser.Id > 0)
            {
                UserState.SetUserState(UserStateEnum.Authenticated);
            }
            
        }
    }
}