using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.Models;
using EventLookup.Domain.DTOs.User;
using EventLookup.Domain.Services;

namespace EventLookup.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersList();
        Task<User> GetUser(int id);
        Task<User> FindUserByEmail(User user);
        Task<bool> SaveUser(User user);
        Task<Event> GetUserEvent(int eventId);
        Task<bool> UpdateUser(User user, string token);
        Task<bool> RemoveUserEvent(int userId, int eventId);
        Task<bool> UploadUserImage(User user, string token);
        Task<bool> MarkUserEvent(UserEvent userEvent);
    }
}
