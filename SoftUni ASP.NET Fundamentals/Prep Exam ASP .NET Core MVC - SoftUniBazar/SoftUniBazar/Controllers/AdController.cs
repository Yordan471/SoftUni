using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Data;
using SoftUniBazar.SoftUniBazar.Service.Contracts;
using SoftUniBazar.ViewModel.Ad;
using static SoftUniBazar.Extensions.ClaimsPrincipleExtensions;

namespace SoftUniBazar.Controllers
{
    public class AdController : BaseController
    {
        private readonly IAdService adService;
        private readonly ICategoryService categoryService;

        public AdController(IAdService adService, ICategoryService categoryService)
        {
            this.adService = adService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ICollection<AllAdViewModel> allAdViewModels = await adService.GetAllAdViewModelsAsync();

            return View(allAdViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddAdViewModel addAdViewModel = new AddAdViewModel()
            {
                Categories = await categoryService.GetAllCategories()
            };

            return View(addAdViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAdViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllCategories();
                return View(model);
            }

            string userId =  GetId(User);

            await adService.SaveAddAdModelToDbAsync(model, userId);

            return RedirectToAction(nameof(All));
        }
    }
}
