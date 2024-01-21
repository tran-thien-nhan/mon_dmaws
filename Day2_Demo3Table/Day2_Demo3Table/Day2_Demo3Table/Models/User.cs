namespace Day2_Demo3Table.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Cart>? Carts { get; set; }    
    }
}
