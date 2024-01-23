using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.SoftUniBazar.Service.Contracts;
using SoftUniBazar.ViewModel;

namespace SoftUniBazar.Controllers
{
    public class AdController : BaseController
    {
        private readonly IAdService adService;

        public AdController(IAdService adService)
        {
            this.adService = adService;
        }

        public async Task<IActionResult> All()
        {
            ICollection<AllAdViewModel> allAdViewModels = await adService.GetAllAdViewModelsAsync();

            return View(allAdViewModels);
        }
    }
}
