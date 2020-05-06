using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLookupBO.Domain
{
    public class UserState
    {
        
        private static readonly UserState instance = new UserState();
        private UserStateEnum CurrentUserState = UserStateEnum.UnAuthenticated;
        

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static UserState()
        {
        }

        private UserState()
        {
        }

        public static UserState Instance
        {
            get
            {
                return instance;
            }
        }

        public bool IsAuthenticated()
        {
            if (CurrentUserState == UserStateEnum.Authenticated)
                return true;

            return false;
        }

        public void SetUserState(UserStateEnum state)
        {
            CurrentUserState = state;
        }

    }

}
