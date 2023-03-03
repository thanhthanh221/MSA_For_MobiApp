using Application.Common.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Market.Coupon.Domain.Model
{
    public class CouponAggregate : IAggregateRoot
    {
        public CouponAggregate(string name,
                               List<string> description,
                               string value,
                               decimal minPriceOrder,
                               decimal moneyIsReduced,
                               int quantity,
                               DateTime expired)
        {
            Id = Guid.NewGuid();
            Name = name.Trim().ToUpper();
            Description = description.Select(de => de.Trim()).ToList();
            Value = value.Trim();
            MinPriceOrder = minPriceOrder;
            MoneyIsReduced = moneyIsReduced;
            Quantity = quantity;
            CouponUsed = 0;
            UserId = new List<Guid>();
            Expired = expired;
        }

        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("Tên")]
        public string Name { get; set; }
        [BsonElement("Mô tả")]
        public List<string> Description { get; set; }
        [BsonElement("Giá trị")]
        public string Value { get; set; }
        [BsonElement("Giá trị tối thiểu")]
        public decimal MinPriceOrder { get; set; }
        [BsonElement("Tiền được giảm")]
        public decimal MoneyIsReduced { get; set; }
        [BsonElement("Số lượng")]
        public int Quantity { get; set; }
        [BsonElement("Mã đã sử dụng")]
        public int CouponUsed { get; set; }
        [BsonElement("User sở hữu")]
        public List<Guid> UserId { get; set; }
        [BsonElement("Ngày hết hạn")]
        public DateTime Expired { get; set; }


        public void SetQuantityCoupon(int newQuantity)
        {
            if (newQuantity <= 0) { return; }

            Quantity = newQuantity;
        }
    }
}