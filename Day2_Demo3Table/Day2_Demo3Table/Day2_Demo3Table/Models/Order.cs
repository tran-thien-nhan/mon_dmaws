namespace Day2_Demo3Table.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<OrderDetail>? Details { get; set; }

        public User? User { get; set; }
    }
}
