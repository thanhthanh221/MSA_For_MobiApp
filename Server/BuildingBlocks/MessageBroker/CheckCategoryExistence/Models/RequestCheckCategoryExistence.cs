namespace CheckCategoryExistence.Models
{
    public class RequestCheckCategoryExistence
    {
        public RequestCheckCategoryExistence(Guid categoryId)
        {
            CategoryId = categoryId;
        }

        public Guid CategoryId { get; set; }
    }
}