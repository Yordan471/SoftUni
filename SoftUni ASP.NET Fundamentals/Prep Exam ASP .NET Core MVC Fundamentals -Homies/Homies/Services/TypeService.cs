using Homies.Data;
using Homies.Services.Contracts;
using Homies.ViewModels.TypeViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Homies.Services
{
    public class TypeService : ITypeService
    {
        private readonly HomiesDbContext dbContext;

        public TypeService(HomiesDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TypeViewModel>> GetAllTypesAsync()
        {
            return await dbContext.Types.Select(t => new TypeViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).AsNoTracking()
            .ToListAsync();
        }
    }
}
