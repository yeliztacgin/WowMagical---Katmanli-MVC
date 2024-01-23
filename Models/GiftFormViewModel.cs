using System.ComponentModel.DataAnnotations;

namespace WowMagical.WebUI.Models
{
    public class GiftFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Kategori adını girmek zorunludur.")]
        public string Name { get; set; }


        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
    }
}
