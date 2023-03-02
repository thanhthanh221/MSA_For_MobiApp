namespace CheckCategoryExistence.Models
{
    public class ResponseCheckCategoryExistence
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Check { get; set; }
    }
}