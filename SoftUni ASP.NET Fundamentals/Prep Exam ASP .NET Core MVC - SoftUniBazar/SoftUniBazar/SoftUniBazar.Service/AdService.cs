using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.SoftUniBazar.Service.Contracts;
using SoftUniBazar.ViewModel.Ad;

namespace SoftUniBazar.SoftUniBazar.Service
{
    public class AdService : IAdService
    {
        private readonly BazarDbContext dbContext;

        public AdService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<AllAdViewModel>> GetAllAdViewModelsAsync()
        {
            return await dbContext.Ads.Select(a => new AllAdViewModel
            {
                Id = a.Id,
                Name = a.Name,
                CreatedOn = a.CreatedOn.ToString(),
                ImageUrl = a.ImageUrl,
                Category = a.Category.Name,
                Description = a.Description,
                Price = a.Price,
                Seller = a.Owner.UserName
            }).ToArrayAsync();
        }
    }
}
