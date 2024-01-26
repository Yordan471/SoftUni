using SoftUniBazar.Data.Models;
using SoftUniBazar.ViewModel.Ad;

namespace SoftUniBazar.SoftUniBazar.Service.Contracts
{
    public interface IAdService
    {
        Task<ICollection<AllAdViewModel>> GetAllAdViewModelsAsync();

        Task SaveAddAdModelToDbAsync(AddAdViewModel model, string userId);

        Task<Ad> GetAdByIdAsync(int id);

        Task<AddAdViewModel> EditAd(Ad adToEdit);
    }
}
