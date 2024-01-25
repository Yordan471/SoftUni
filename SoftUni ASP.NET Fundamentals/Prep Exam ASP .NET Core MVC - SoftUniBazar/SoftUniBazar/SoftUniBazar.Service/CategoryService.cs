using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.SoftUniBazar.Service.Contracts;
using SoftUniBazar.ViewModel.Category;

namespace SoftUniBazar.SoftUniBazar.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly BazarDbContext dbContext;

        public CategoryService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            return await dbContext.Categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToArrayAsync();
        }
    }
}
