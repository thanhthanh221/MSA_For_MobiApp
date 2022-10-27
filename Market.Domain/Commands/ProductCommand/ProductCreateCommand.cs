using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Market.Domain.Validations.ProductValidation;

namespace Market.Domain.Commands.ProductCommand
{
    public class ProductCreateCommand : ProductCommand
    {

        public ProductCreateCommand(Guid Id,
                                       string Name,
                                       decimal Price,
                                       int Calo,
                                       string Image,
                                       string Descretion,
                                       string Alias,
                                       int Warranty,
                                       Decimal PromotionPrice,
                                       int Quantity,
                                       decimal OriginalPrice,
                                       DateTimeOffset CreateAt,
                                       Guid CreateBy)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Image = Image;
            this.Calo = Calo;
            this.Alias = Alias;
            this.Quantity = Quantity;
            this.Warranty = Warranty;
            this.PromotionPrice = PromotionPrice;
            this.OriginalPrice = OriginalPrice;
            this.CreateAt = CreateAt;
            this.CreateBy = CreateBy;
            this.Image = Image;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProductCreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
