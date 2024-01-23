using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowMagical.Business.Dtos
{
    public class ProductDetailDto
    {
        public string Name  { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string CategoryName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CategoryId { get; set; }

    }
}
