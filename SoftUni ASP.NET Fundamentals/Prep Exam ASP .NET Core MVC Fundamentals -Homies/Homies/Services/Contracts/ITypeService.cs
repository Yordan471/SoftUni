using Homies.ViewModels.TypeViewModels;

namespace Homies.Services.Contracts
{
    public interface ITypeService
    {
        public Task<IEnumerable<TypeViewModel>> GetAllTypesAsync();
    }
}
