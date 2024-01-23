using SoftUniBazar.ViewModel;

namespace SoftUniBazar.SoftUniBazar.Service.Contracts
{
    public interface IAdService
    {
        Task<ICollection<AllAdViewModel>> GetAllAdViewModelsAsync();
    }
}
