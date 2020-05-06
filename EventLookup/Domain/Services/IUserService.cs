using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.DTOs.User;
using EventLookup.Domain.Models;

namespace EventLookup.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersList();
        Task<UserDTO> GetUser(int id);
        Task<AuthenticationUser> UserLoginWithToken(string token);
        Task<AuthenticationUser> UserLogin(User user);
        Task<AuthenticationUser> UserRegister(User user);
        Task<bool> UpdateUser(User user, string token);
        Task<bool> RemoveUserEvent(int userId, int eventId);
        Task<bool> UploadUserImage(User user, string token);
        Task<bool> MarkUserEvent(UserEvent userEvent);
        Task<bool> ChangePassword(ChangePasswordDTO user);
    }
}
