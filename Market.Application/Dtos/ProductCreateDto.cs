using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Dtos
{
    public class ProductCreateDto 
    {
        public ProductCreateDto(string name,
                                decimal price,
                                IFormFile image,
                                int calo,
                                string descretion,
                                string alias,
                                int warranty,
                                decimal promotionPrice,
                                int quantity,
                                decimal originalPrice,
                                Guid createBy)
        {
            Name = name;
            Price = price;
            Image = image;
            Calo = calo;
            Descretion = descretion;
            Alias = alias;
            Warranty = warranty;
            PromotionPrice = promotionPrice;
            Quantity = quantity;
            OriginalPrice = originalPrice;
            CreateBy = createBy;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public IFormFile Image { get; private set; }
        public int Calo { get; private set; }
        public string Descretion { get; private set; }
        public string Alias { get; private set; }
        public int Warranty { get; private set; } // bảo hành
        public decimal PromotionPrice { get; private set; } // giá khuyến mãi
        public int Quantity { get; private set; }
        public decimal OriginalPrice { get; private set; }
        public Guid CreateBy { get; set; }  
        public Guid UpdateBy { get; set; }
    }
}
