using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.EntityValidationsConstants.User;
using static Watchlist.Common.EntityValidationsErrorMessages.User;

namespace Watchlist.ViewModels.UserViewModels
{
    public class UserLoginViewModel
    {
        /// <summary>
        /// Login username
        /// </summary>
        [Required]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Login password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
