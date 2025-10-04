using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Entities;

namespace EntityFramework1.Repositories
{
    public class TeacherRepository
    {
        private readonly OnlineСoursesContext _db;
        public TeacherRepository(OnlineСoursesContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Teacher teacher)
        {
            _db.Teachers.AddAsync(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Teacher teacher)
        {
            _db.Teachers.Remove(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _db.Teachers.Update(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            var teachers = await _db.Teachers.ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var teacher = await _db.Teachers.FindAsync(id);
            return teacher;
        }

        public async Task<Teacher> GetByNameAsync(string name)
        {
            var teacher = await _db.Teachers.FirstOrDefaultAsync(d => d.Name == name);
            return teacher;
        }
    }
}
