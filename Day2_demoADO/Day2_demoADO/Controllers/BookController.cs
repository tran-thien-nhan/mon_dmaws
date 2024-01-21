using Day2_demoADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Day2_demoADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetList()
        {
            string conStr = "Server=.;Database=DemoADO;User=sa;Password=123;TrustServerCertificate=true";
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT * FROM Book";
            SqlCommand conCmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = conCmd.ExecuteReader();
            List<Book> books = new List<Book>();
            while (reader.Read())
            {
                Book book = new Book();
                book.Id = (int)reader["id"];
                book.Title = (string)reader["title"];
                book.Author = (string)reader["author"];
                book.Edition = (int)reader["editor"];
                book.Price = (int)reader["price"];
                books.Add(book);
            }
            con.Close();
            return Ok(books);   
        }
    }
}
