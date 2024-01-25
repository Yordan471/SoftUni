﻿using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.SoftUniBazar.Service.Contracts;
using SoftUniBazar.ViewModel.Ad;

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
    }
}
