using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Data;
using SoftUniBazar.SoftUniBazar.Service.Contracts;
using SoftUniBazar.ViewModel.Ad;
using static SoftUniBazar.Extensions.ClaimsPrincipleExtensions;
using static SoftUniBazar.Common.EntityValidationErrorMessages;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Extensions;

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
            var categories = await categoryService.GetAllCategories();
            
            if (!categories.Any(c => c.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesNotExist);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllCategories();
                return View(model);
            }

            string userId =  GetId(User);

            await adService.SaveAddAdModelToDbAsync(model, userId);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Ad ad = await adService.GetAdByIdAsync(id);

            if (ad == null)
            {
                return BadRequest();
            }

            string currentUseUd = GetId(this.User);
            if (ad.Owner.Id != currentUseUd)
            {
                return Unauthorized();
            }

            return adService.EditAd(ad);
        }
    }
}
