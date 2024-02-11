namespace Watchlist.ViewModels.MovieViewModels
{
    public class MovieViewModel
    {
        /// <summary>
        /// Movie identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Movie Title
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Movie director name
        /// </summary>
        public string Director { get; set; } = string.Empty;

        /// <summary>
        /// Movie score rating
        /// </summary>
        public decimal Rating { get; set; }

        /// <summary>
        /// Movie genre
        /// </summary>
        public string Genre { get; set; } = string.Empty;

        /// <summary>
        /// Movie image path
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}
