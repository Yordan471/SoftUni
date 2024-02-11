using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.EntityValidationsConstants.User;

namespace Watchlist.Data.Models
{
    public class User : IdentityUser
    {
        public User() 
        {
            UsersMovies = new HashSet<UserMovie>();
        }

        [Comment("Collection of user Id's and movie Id's")]
        public ICollection<UserMovie> UsersMovies { get; set; }

    }
}
