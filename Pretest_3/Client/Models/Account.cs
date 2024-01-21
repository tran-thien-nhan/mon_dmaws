using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class Account
    {
        [Key]
        public string Username {  get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
    }
}
