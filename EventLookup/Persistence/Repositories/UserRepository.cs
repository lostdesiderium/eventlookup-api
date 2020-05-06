using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.Models;
using EventLookup.Domain.Repositories;
using EventLookup.Persistence.Context;
using Microsoft.EntityFrameworkCore;

using EventLookup.Domain.DTOs.User;

namespace EventLookup.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(EventLookupContext context) : base(context)
        {

        }

        public async Task<IEnumerable<User>> GetUsersList()
        {
            var users = await _eventLookupContext.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _eventLookupContext.Users
                .Include(u => u.UserEvents)
                .FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }

        public async Task<User> FindUserByEmail(User user)
        {
            var userFromDb = await _eventLookupContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == user.Email.ToLower());

            return userFromDb;
        }

        public async Task<bool> UpdateUser(User user, string token)
        {
            var currentUser = await FindUserByEmail(user);
            if (currentUser != null)
            {
                currentUser.Biography = user.Biography;
                _eventLookupContext.Users.Update(currentUser);
                _eventLookupContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> UploadUserImage(User user, string token)
        {
            var currentUser = await FindUserByEmail(user);
            if(currentUser != null)
            {
                currentUser.ImagePath = user.ImagePath;
                _eventLookupContext.Users.Update(currentUser);
                _eventLookupContext.SaveChanges();
            }

            return false;
        }

        public async Task<bool> MarkUserEvent(UserEvent userEvent)
        {
            bool decreaseGoingCounter = false;
            bool decreaseInterestedCounter = false;

            var userEventFromDb = await _eventLookupContext.UserEvents.FirstOrDefaultAsync(ue => ue.EventId == userEvent.EventId && ue.UserId == userEvent.UserId);
            if(userEventFromDb != null)
            {
                bool isGoing = userEventFromDb.Going;
                bool isInterested = userEventFromDb.Interested;
                if (userEventFromDb.Going != userEvent.Going && userEventFromDb.Interested != userEvent.Interested) // means needs to switch from going to interested and increase/decrease counter
                {
                    if (userEvent.Going)
                        decreaseInterestedCounter = true;
                    else if (userEvent.Interested)
                        decreaseGoingCounter = true;
                }

                userEventFromDb.Going = userEvent.Going;
                userEventFromDb.Interested = userEvent.Interested;
                userEventFromDb.Created = userEvent.Created;
                _eventLookupContext.UserEvents.Update(userEventFromDb);
                if ( await _eventLookupContext.SaveChangesAsync() > 0)
                {
                    if (userEvent.Going == false && userEvent.Interested == false)
                    {
                        await UpdateEventLikesCounterDecreaseAsync(userEvent, isGoing, isInterested);
                    }
                    else
                    {
                        await UpdateEventLikesCounterIncreaseAsync(userEvent, decreaseGoingCounter, decreaseInterestedCounter);
                    }
                    
                    return true;
                }
                    
            }

            _eventLookupContext.UserEvents.Add(userEvent);
            if (await _eventLookupContext.SaveChangesAsync() > 0)
            {
                await UpdateEventLikesCounterIncreaseAsync(userEvent, decreaseGoingCounter, decreaseInterestedCounter);
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveUserEvent(int userId, int eventId)
        {
            var userEvent = await _eventLookupContext.UserEvents.FirstOrDefaultAsync(ue => ue.EventId == eventId && ue.UserId == userId);
            if(userEvent != null)
            {
                _eventLookupContext.UserEvents.Remove(userEvent);
                _eventLookupContext.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<bool> SaveUser(User user)
        {
            var currentUser = await FindUserByEmail(user);

            if(currentUser != null)
            {
                _eventLookupContext.Users.Update(currentUser);
                _eventLookupContext.SaveChanges();
                return true;
            }

            _eventLookupContext.Users.Add(user);
            _eventLookupContext.SaveChanges();

            return true;
        }

        public async Task<Event> GetUserEvent(int eventId)
        {
            var userEvent = await _eventLookupContext.Events
                .Include(ev => ev.Images)
                .FirstOrDefaultAsync(e => e.EventId == eventId);
            return userEvent;
        }

        private async Task<int> UpdateEventLikesCounterIncreaseAsync(UserEvent ue, bool decreaseGoingCounter, bool decreaseInterestedCounter)
        {
            var oneEvent = await _eventLookupContext.Events.FirstOrDefaultAsync(e => e.EventId == ue.EventId);
            if (oneEvent != null)
            {
                if (ue.Interested == true)
                {
                    oneEvent.InterestedPeopleCount++;
                    if (decreaseGoingCounter)
                        oneEvent.GoingPeopleCount--;
                    _eventLookupContext.Events.Update(oneEvent);
                    return await _eventLookupContext.SaveChangesAsync();
                }

                else if (ue.Going == true)
                {
                    oneEvent.GoingPeopleCount++;
                    if (decreaseInterestedCounter)
                        oneEvent.InterestedPeopleCount--;
                    _eventLookupContext.Events.Update(oneEvent);
                    return await _eventLookupContext.SaveChangesAsync();
                }
            }
            return 0;
        }

        private async Task<int> UpdateEventLikesCounterDecreaseAsync(UserEvent ue, bool isGoing, bool isInterested)
        {
            var oneEvent = await _eventLookupContext.Events.FirstOrDefaultAsync(e => e.EventId == ue.EventId);
            if (oneEvent != null)
            {
                if (isInterested == true)
                {
                    oneEvent.InterestedPeopleCount--;
                    _eventLookupContext.Events.Update(oneEvent);
                    return await _eventLookupContext.SaveChangesAsync();
                }

                else if (isGoing == true)
                {
                    oneEvent.GoingPeopleCount--;
                    _eventLookupContext.Events.Update(oneEvent);
                    return await _eventLookupContext.SaveChangesAsync();
                }
            }
            return 0;
        }

    }
}
