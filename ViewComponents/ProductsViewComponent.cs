using Microsoft.AspNetCore.Mvc;
using WowMagical.Business.Services;
using WowMagical.WebUI.Models;

namespace WowMagical.WebUI.ViewComponents
{
    public class ProductsViewComponent :ViewComponent
    {
        private readonly IProductService _productService;

        public ProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke(int? categoryId = null)
        {

            var productDtos = _productService.GetProductsByCategoryId(categoryId);

            var viewModel = productDtos.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                UnitsInStock = x.UnitsInStock,
                UnitPrice = x.UnitPrice,
                ImagePath = x.ImagePath,
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();

            return View(viewModel);
        }
    }
}

