using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.SoftUniBazar.Service.Contracts;
using SoftUniBazar.ViewModel.Ad;

namespace SoftUniBazar.SoftUniBazar.Service
{
    public class AdService : IAdService
    {
        private readonly BazarDbContext dbContext;
        private readonly ICategoryService categoryService;

        public AdService(BazarDbContext dbContext, ICategoryService categoryService)
        {
            this.dbContext = dbContext;
            this.categoryService = categoryService;
        }

        public async Task<AddAdViewModel> EditAd(Ad adToEdit)
        {
            AddAdViewModel editedAd = new()
            {
                Name = adToEdit.Name,
                Description = adToEdit.Description,
                ImageUrl = adToEdit.ImageUrl,
                Price = adToEdit.Price,
                CategoryId = adToEdit.CategoryId,
                Categories = await categoryService.GetAllCategories()
            };

            return editedAd;
        }

        public async Task<Ad> GetAdByIdAsync(int id)
        {
            return await dbContext.Ads.FirstAsync(a => a.Id == id);
        }

        public async Task<ICollection<AllAdViewModel>> GetAllAdViewModelsAsync()
        {
            string? ownerName = await dbContext.Ads.Select(a => a.Owner.UserName).FirstOrDefaultAsync();

            return await dbContext.Ads.Select(a => new AllAdViewModel
            {
                Id = a.Id,
                Name = a.Name,
                CreatedOn = a.CreatedOn.ToString(),
                ImageUrl = a.ImageUrl,
                Category = a.Category.Name,
                Description = a.Description,
                Price = a.Price,
                Owner = a.Owner.UserName
            }).ToArrayAsync();
        }

        public async Task SaveAddAdModelToDbAsync(AddAdViewModel model, string userId)
        {
            string dateTimeNow = DateTime.UtcNow.ToString("yyyy-MM-dd H:mm");
            DateTime dateTime = DateTime.Parse(dateTimeNow);

            Ad ad = new()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                OwnerId = userId,
                ImageUrl = model.ImageUrl,
                CreatedOn = dateTime,
                CategoryId = model.CategoryId,
            };

            await dbContext.Ads.AddAsync(ad);
            await dbContext.SaveChangesAsync();
        }
    }
}
