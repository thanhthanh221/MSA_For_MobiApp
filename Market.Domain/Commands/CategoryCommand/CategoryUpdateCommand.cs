namespace Market.Domain.Commands.CategoryCommand
{
    public class CategoryUpdateCommand : CategoryCommand
    {
        protected CategoryUpdateCommand(Guid id,
                                        string name,
                                        string alias,
                                        string description,
                                        string image,
                                        DateTimeOffset createAt,
                                        Guid createBy,
                                        DateTimeOffset updateAt,
                                        Guid updateBy)
        {
            Id = id;
            this.name = name;
            this.alias = alias;
            this.description = description;
            this.image = image;
            CreateAt = createAt;
            CreateBy = createBy;
            UpdateAt = updateAt;
            UpdateBy = updateBy;
        }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
