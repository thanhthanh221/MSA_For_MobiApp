using Market.Domain.Validations;

namespace Market.Domain.Commands
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid Id,
                                    string Name,
                                    decimal price,
                                    int calo,
                                    string descretion,
                                    string alias,
                                    string image,
                                    int warranty,
                                    decimal promotionPrice,
                                    int Quantity,
                                    decimal originalPrice,
                                    DateTimeOffset UpdateAt,
                                    Guid UpdateBy
                                    )
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = price;
            this.Calo = calo;
            this.Descretion = descretion;
            this.Alias = alias;
            this.Warranty = warranty;
            this.OriginalPrice = originalPrice;
            this.Image = image;
            this.PromotionPrice = promotionPrice;
            this.UpdateAt = UpdateAt;
            this.UpdateBy = UpdateBy;
            this.Quantity = Quantity;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}