using Microsoft.AspNetCore.Mvc;
using WowMagical.Business.Services;
using WowMagical.WebUI.Models;

namespace WowMagical.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Detail(int id)
        {
            var productDetailDto = _productService.GetProductDetailById(id);

            var viewModel = new ProductDetailViewModel()
            {
                Name = productDetailDto.Name,
                Description = productDetailDto.Description,
                ImagePath = productDetailDto.ImagePath,
                UnitPrice = productDetailDto.UnitPrice,
                UnitsInStock = productDetailDto.UnitsInStock,
                CategoryName = productDetailDto.CategoryName,
                ModifiedDate= productDetailDto.ModifiedDate,
                CategoryId = productDetailDto.CategoryId

            };
            
            return View(viewModel);
        }
    }
}
