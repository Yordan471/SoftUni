using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchlist.Common
{
    public static class EntityValidationsErrorMessages
    {
        public static class User
        {
            public const string UsernameInccorectLength = "Username must be between {2} and {1} characters long!";
            public const string PasswordInccorectLength = "Password must be between {2} and {1} characters long!";
            public const string EmailInccorectLength = "Email must be between {2} and {1} characters long!";
        }

        public static class Movie
        {
            public const string TitleInccorectLength = "Title must be between {2} and {1} characters long!";
            public const string DirectorInccorectLength = "Director name must be between {2} and {1} characters long!";
        }
    }
}
