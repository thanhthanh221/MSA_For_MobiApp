using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Dtos
{
    public class ProductWriteDto 
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Calo { get; set; }
        public string Descretion { get; set; }
        public string Alias { get; set; }
        public int Warranty { get; set; } // bảo hành
        public decimal PromotionPrice { get; set; } // giá khuyến mãi
        public int Quantity { get; set; }
        public decimal OriginalPrice { get; set; } // Gía gốc
        public Guid UserId { get; set; } 
        public IFormFile Image { get; set; }
    }
}
