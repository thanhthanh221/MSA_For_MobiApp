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
                              Guid createBy,
                              DateTimeOffset createAt)
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
            CreateBy = createBy;
            CreateAt = createAt;
        }

        public Guid Id {get; set;}
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Calo { get; set; }
        public string Descretion { get; set; }
        public string Alias { get; set; }
        public int Warranty { get; set; } // bảo hành
        public decimal PromotionPrice { get; set; } // giá khuyến mãi
        public int Quantity { get; set; }
        public decimal OriginalPrice { get; set; }
        public Guid CreateBy {get; set;}
        public DateTimeOffset CreateAt {get; set;}
        public Guid UpdateBy {get; set;}
        public DateTimeOffset UpdateAt {get; set;}
    }
}
