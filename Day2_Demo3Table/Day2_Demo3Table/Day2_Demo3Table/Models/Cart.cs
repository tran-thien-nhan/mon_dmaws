﻿namespace Day2_Demo3Table.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }

        public Product? Product { get; set; }
        public User? User { get; set; }
        
    }
}
