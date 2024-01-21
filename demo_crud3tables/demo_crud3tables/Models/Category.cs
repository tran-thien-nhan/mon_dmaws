using System.ComponentModel.DataAnnotations;

namespace demo_crud3tables.Models
{
    public class Category
    {
        public string CategoryID { get; set; }
        public string? CategoryName { get; set; }

        public bool? Visibility { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
