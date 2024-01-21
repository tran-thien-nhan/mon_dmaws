namespace demo_crud3tables.Models
{
    public class Supplier
    {
        public string SupplierID { get; set; }
        public string? SupplierName { get; set; }
        public string? City { get; set; }

        public bool? Visibility { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
