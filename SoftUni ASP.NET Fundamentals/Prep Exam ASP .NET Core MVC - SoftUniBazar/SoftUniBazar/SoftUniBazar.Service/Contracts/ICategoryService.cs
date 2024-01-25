using SoftUniBazar.ViewModel.Category;

namespace SoftUniBazar.SoftUniBazar.Service.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
    }
}
