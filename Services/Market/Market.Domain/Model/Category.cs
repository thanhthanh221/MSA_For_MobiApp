using Market.Domain.Models;
namespace Market.Domain.Model
{
    public class Category : IAggregate
    {
        public Category(string name,
                        string image)
        {
            Id = Guid.NewGuid();
            ParentCategory = new List<Category>();
            Name = name;
            Image = image;
        }

        public Guid Id {get; private set;}
        public string Name { get; private set; }
        public string Image { get; private set; }
        public List<Category> ParentCategory { set; private get; }

        public bool UpdateParentCategory(List<Category> categories)
        {
            if(categories.Count == 0)
            {
                return false;
            }
            ParentCategory = categories; 
            return true;         
        }
    }
}
