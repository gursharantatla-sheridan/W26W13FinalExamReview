namespace W26W13FinalExamReview.Models
{
    public class Category
    {
        // scalar properties
        public int CategoryId { get; set; }  // primary key
        public string? CategoryName { get; set; }

        // navigation property
        public ICollection<Product>? Products { get; set; }
    }
}
