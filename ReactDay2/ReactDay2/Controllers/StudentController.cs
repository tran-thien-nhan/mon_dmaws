using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactDay2.Models;
using ReactDay2.Repository;

namespace ReactDay2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo repo;

        public StudentController(IStudentRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await repo.GetStudents());
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            return Ok(await repo.AddStudent(student));
        }

        [HttpPut]
        public async Task<IActionResult> PutStudent(Student student)
        {
            return Ok(await repo.UpdateStudent(student));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            return Ok(await repo.DeleteStudent(id));
        }
    }
}
