using SoftUniBazar.ViewModel.Ad;

namespace SoftUniBazar.SoftUniBazar.Service.Contracts
{
    public interface IAdService
    {
        Task<ICollection<AllAdViewModel>> GetAllAdViewModelsAsync();

        Task SaveAddAdModelToDbAsync(AddAdViewModel model, string userId);
    }
}
