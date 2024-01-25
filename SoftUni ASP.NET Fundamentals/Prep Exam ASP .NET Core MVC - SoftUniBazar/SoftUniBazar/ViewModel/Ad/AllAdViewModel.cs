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
        public string Name { get; set; } = null!;

        /// <summary>
        /// Ad image
        /// </summary>
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Ad date of creation
        /// </summary>
        public string CreatedOn { get; set; } = null!;

        /// <summary>
        /// Ad category
        /// </summary>
        public string Category { get; set; } = null!;

        /// <summary>
        /// Ad description
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// Ad Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Ad Seller
        /// </summary>
        public string Seller { get; set; } = null!;
    }
}
