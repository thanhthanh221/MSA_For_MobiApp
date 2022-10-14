using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Dtos
{
    public class ProductReadDto
    {
        public ProductReadDto(Guid id,
                              string name,
                              decimal price,
                              int calo,
                              string descretion,
                              string alias,
                              int warranty,
                              decimal promotionPrice,
                              int quantity,
                              decimal originalPrice,
                              Guid createBy)
        {
            Id = id;
            Name = name;
            Price = price;
            Calo = calo;
            Descretion = descretion;
            Alias = alias;
            Warranty = warranty;
            PromotionPrice = promotionPrice;
            Quantity = quantity;
            OriginalPrice = originalPrice;
            this.createBy = createBy;
        }

        public Guid Id {get; private set;}
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Calo { get; private set; }
        public string Descretion { get; private set; }
        public string Alias { get; private set; }
        public int Warranty { get; private set; } // bảo hành
        public decimal PromotionPrice { get; private set; } // giá khuyến mãi
        public int Quantity { get; private set; }
        public decimal OriginalPrice { get; private set; }
        public Guid createBy {get; private set;}
    }
}
