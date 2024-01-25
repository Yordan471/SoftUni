namespace SoftUniBazar.ViewModel.Ad
{
    public class AllAdViewModel
    {
        /// <summary>
        /// Ad identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of Ad
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Ad image
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Ad date of creation
        /// </summary>
        public string CreatedOn { get; set; } = string.Empty;

        /// <summary>
        /// Ad category
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Ad description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Ad Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Ad Seller
        /// </summary>
        public string Owner { get; set; } = string.Empty;
    }
}
