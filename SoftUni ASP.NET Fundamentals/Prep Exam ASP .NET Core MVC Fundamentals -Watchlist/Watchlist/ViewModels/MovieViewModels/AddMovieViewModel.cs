using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Watchlist.ViewModels.GenreViewModel;
using static Watchlist.Common.EntityValidationsConstants.Movie;
using static Watchlist.Common.EntityValidationsErrorMessages.Movie;

namespace Watchlist.ViewModels.MovieViewModels
{
    public class AddMovieViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
            ErrorMessage = TitleInccorectLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DirectorMaxLength, MinimumLength = DirectorMinLength,
            ErrorMessage = DirectorInccorectLength)]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Range((double)RatingMinValue, (double)RatingMaxValue, 
            ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        public IEnumerable<AllGenreViewModel> Genres { get; set; } = new List<AllGenreViewModel>();
    }
}
