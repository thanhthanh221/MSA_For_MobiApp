using Application.Common.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Market.Domain.CouponService.Model
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
            UserId =  new List<Guid>();
            Expired = expired;
        }

        [BsonId]
        public Guid Id { get; private set; }
        [BsonElement("Tên")]
        public string Name { get; private set; }
        [BsonElement("Mô tả")]
        public List<string> Description { get; private set; }
        [BsonElement("Giá trị")]
        public string Value { get; private set; }
        [BsonElement("Giá trị tối thiểu")]
        public decimal MinPriceOrder { get; private set; }
        [BsonElement("Tiền được giảm")]
        public decimal MoneyIsReduced { get; private set; }
        [BsonElement("Số lượng")]
        public int Quantity { get; private set; }
        [BsonElement("Mã đã sử dụng")]
        public int CouponUsed { get; private set; }
        [BsonElement("User sở hữu")]
        public List<Guid> UserId { get; private set; }
        [BsonElement("Ngày hết hạn")]
        public DateTime Expired { get; private set; }



        public void SetQuantityCoupon(int newQuantity)
        {
            if (newQuantity <= 0) { return; }

            Quantity = newQuantity;
        }
    }
}