namespace Market.Domain.Commands.CategoryCommand
{
    public class CategoryCreateCommand : CategoryCommand
    {
        public CategoryCreateCommand(Guid id,
                                     string name,
                                     string alias,
                                     string description,
                                     string image,
                                     DateTimeOffset createAt,
                                     Guid createBy)
        {
            Id = id;
            this.name = name;
            this.alias = alias;
            this.description = description;
            this.image = image;
            CreateAt = createAt;
            CreateBy = createBy;
        }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
