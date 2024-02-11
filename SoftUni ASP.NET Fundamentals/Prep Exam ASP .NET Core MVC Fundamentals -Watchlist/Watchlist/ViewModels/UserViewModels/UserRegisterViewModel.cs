using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.EntityValidationsConstants.User;
using static Watchlist.Common.EntityValidationsErrorMessages.User;

namespace Watchlist.ViewModels.UserViewModels
{
    public class UserRegisterViewModel
    {
        /// <summary>
        /// Login username
        /// </summary>
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength,
            ErrorMessage = UsernameInccorectLength)]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Login password
        /// </summary>
        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
            ErrorMessage = PasswordInccorectLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Register email
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength,
            ErrorMessage = EmailInccorectLength)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Register confirm password compare with Password
        /// </summary>
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
