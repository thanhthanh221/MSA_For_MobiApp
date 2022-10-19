using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Market.Domain.Validations;
using MediatR;

namespace Market.Domain.Commands
{
    public class CreateNewProductCommand : ProductCommand
    {

        public CreateNewProductCommand(Guid Id,
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
            ValidationResult = new CreateNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
