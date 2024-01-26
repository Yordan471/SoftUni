using SoftUniBazar.Data.Models;
using SoftUniBazar.ViewModel.Ad;

namespace SoftUniBazar.SoftUniBazar.Service.Contracts
{
    public interface IAdService
    {
        Task<ICollection<AllAdViewModel>> GetAllAdViewModelsAsync();

        Task SaveAddAdModelToDbAsync(AddAdViewModel model, string userId);

        Task<Ad> GetAdByIdAsync(int id);

        Task<AddAdViewModel> GetEditAdAsync(Ad adToEdit);

        Task PostEditAdAsync(Ad adToEdit, AddAdViewModel model);

        Task<bool> AdBuyerEntryExistAsync(AdBuyer entry);

        Task AddAdBuyerEntryAsync(AdBuyer entry);

        Task<ICollection<AllAdViewModel>> GetAllAdsForBuyerAsync(string userId);

        Task RemoveAdBuyerEntryAsync(AdBuyer entry);
    }
}
