using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json.Serialization;

namespace demo_crud3tables.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string? SupplierID { get; set; }
        public string? CategoryID { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public string? ImagePath { get; set; }

        public bool? Visibility { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [JsonIgnore]
        public Supplier? Supplier { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
