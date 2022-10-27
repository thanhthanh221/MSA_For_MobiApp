using Market.Domain.Core.Commands;

namespace Market.Domain.Commands.CategoryCommand
{
    public abstract class CategoryCommand : Command
    {
        public Guid Id { get; set; }
        public String name { get; protected set; }
        public String alias { get; protected set; }
        public String description { get; protected set; }
        public String image { get; protected set; }
        public DateTimeOffset CreateAt { get; set; }
        public Guid CreateBy { get; set; }
        public DateTimeOffset UpdateAt { get; set; }
        public Guid UpdateBy { get; set; }
    }
}