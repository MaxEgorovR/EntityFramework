using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Entities;

// Ошибка при update-database
/*Введение ограничения внешнего ключа (FOREIGN KEY) "FK_Review_Student_StudentId" для таблицы "Review" может привести к появлению циклов или множественных каскадных путей. Укажите ON DELETE NO ACTION или ON UPDATE NO ACTION либо измените другие ограничения внешнего ключа (FOREIGN KEY).
Не удалось создать ограничение или индекс. См. описание предыдущих ошибок.*/
// => функции будут подчёркиваться

namespace EntityFramework1.Repositories
{
    public class CourseRepository
    {
        private readonly OnlineСoursesContext _db;
        public CourseRepository(OnlineСoursesContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Course course)
        {
            _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Course course)
        {
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            _db.Courses.Update(course);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllAsync()
        {
            var courses = await _db.Courses.ToListAsync();
            return courses;
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            return course;
        }

        public async Task<Course> GetByNameAsync(string name)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(d => d.Name == name);
            return course;
        }
    }
}
