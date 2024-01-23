namespace WowMagical.WebUI.Models
{
    public class ProductDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string CategoryName { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public TimeSpan? LastUpdate
        {
            get
            {
                return DateTime.Now - ModifiedDate;
            }
        }

        public int CategoryId { get; set; }


    }
}
