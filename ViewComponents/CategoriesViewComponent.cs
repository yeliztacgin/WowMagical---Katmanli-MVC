using Microsoft.AspNetCore.Mvc;
using WowMagical.Business.Services;
using WowMagical.WebUI.Models;

namespace WowMagical.WebUI.ViewComponents
{
    public class CategoriesViewComponent :ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


       
        public IViewComponentResult Invoke()
        {
            var categoryDtos = _categoryService.GetCategories();

            var viewModel = categoryDtos.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();


            return View(viewModel);
        }

    }
}

