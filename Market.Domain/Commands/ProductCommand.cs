using Market.Domain.Core.Commands;

namespace Market.Domain.Commands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id {get; set;}
        public string Name {get; protected set;}
        public decimal Price {get; protected set;}
        public string Descretion {get; protected set;}
        public int Calo { get; protected set; }
        public string Alias { get; protected set; }
        public int Quantity { get; protected set; }
        public int Warranty { get; protected set; } // bảo hành
        public decimal PromotionPrice { get; protected set; } // giá khuyến mãi
        public decimal OriginalPrice { get; protected set; }
        public string Image {get; protected set;}
        public DateTimeOffset CreateAt { get;protected set; }
        public Guid CreateBy { get;protected set; }  
        public DateTimeOffset UpdateAt { get;protected set; }
        public Guid UpdateBy { get;protected set; }
        
    }
}