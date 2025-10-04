using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Entities;

namespace EntityFramework1.Repositories
{
    public class StudentRepository
    {
        private readonly OnlineСoursesContext _db;
        public StudentRepository(OnlineСoursesContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Student student)
        {
            _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student student)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var students = await _db.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _db.Students.FindAsync(id);
            return student;
        }

        public async Task<Student> GetByNameAsync(string name)
        {
            var student = await _db.Students.FirstOrDefaultAsync(d => d.Name == name);
            return student;
        }
    }
}
