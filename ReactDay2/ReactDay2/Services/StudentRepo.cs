using Microsoft.EntityFrameworkCore;
using ReactDay2.Data;
using ReactDay2.Models;
using ReactDay2.Repository;

namespace ReactDay2.Services
{
    public class StudentRepo : IStudentRepo
    {
        private readonly DatabaseContext db;

        public StudentRepo(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<Student> AddStudent(Student student)
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await db.Students.FindAsync(id);
            if (student != null)
            {
                db.Students.Remove(student);
                await db.SaveChangesAsync();
            }
            return student;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await db.Students.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await db.Students.FindAsync(student.Id);
            if (result != null)
            {
                result.Name = student.Name;
                result.Mark = student.Mark;
                result.Email = student.Email;
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
