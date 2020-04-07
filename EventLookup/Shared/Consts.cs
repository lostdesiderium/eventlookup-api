using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLookup.Shared
{
    public class Consts
    {
        private Tuple<int, string> USER_EXISTS = new Tuple<int, string>( 1, "Email exists" );
        private Tuple<int, string> INVALID_PASSWORD = new Tuple<int, string>( 2, "Invalid password" );
        private Tuple<int, string> NO_USER = new Tuple<int, string>(3, "There is no such user");
        private Tuple<int, string> TOKEN_EXPIRED = new Tuple<int, string>(4, "Token expired");
        private Tuple<int, string> PROBLEMS_WITH_SERVER = new Tuple<int, string>(5, "We apologize, there are problems with server");

        private static readonly Consts _instance = new Consts();

        static Consts() { }

        private Consts() { }


        public static Consts Instance
        {
            get
            {
                return _instance;
            }
        }

        public Tuple<int, string> getUserExistsTuple()
        {
            return USER_EXISTS;
        }
        public Tuple<int, string> getInvalidPasswordTuple()
        {
            return INVALID_PASSWORD;
        }
        public Tuple<int, string> getNoUserTuple()
        {
            return NO_USER;
        }
        public Tuple<int, string> getTokenExpiredTuple()
        {
            return TOKEN_EXPIRED;
        }
        public Tuple<int, string> getProblemsWithServerTuple()
        {
            return PROBLEMS_WITH_SERVER;
        }

    }
}
