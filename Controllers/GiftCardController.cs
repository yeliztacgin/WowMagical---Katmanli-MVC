using Microsoft.AspNetCore.Mvc;
using WowMagical.Business.Dtos;
using WowMagical.WebUI.Areas.Admin.Models;
using WowMagical.WebUI.Models;

namespace WowMagical.WebUI.Controllers
{
    public class GiftCardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] // form'dan tetiklenir.
        public IActionResult Save(GiftFormViewModel formData)
        {

           if (formData.Id == 0) // EKLEME İŞLEMİ
            {
                var addGiftDto = new AddGiftDto()
                {
                    Name = formData.Name.Trim(),
                    Description = formData.Description
                };
            }
            else
            {

                
                    return View("Form", formData);
                




            }
            return View();
        }
    }
}