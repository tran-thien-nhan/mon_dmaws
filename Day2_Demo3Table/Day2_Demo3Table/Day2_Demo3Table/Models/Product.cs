namespace Day2_Demo3Table.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public ICollection<Cart>? Carts { get; set; }
    }
}
