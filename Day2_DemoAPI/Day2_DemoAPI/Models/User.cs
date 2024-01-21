using System.ComponentModel.DataAnnotations;

namespace Day2_DemoAPI.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int YoB { get; set; }
    }
}
