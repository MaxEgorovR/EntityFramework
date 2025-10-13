using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Entities;
using EntityFramework1.Repositories;

namespace EntityFramework1.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(OnlineСoursesContext db)
        {
            _courseRepository = new CourseRepository(db);
        }

        public async Task AddAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var cour = _courseRepository.GetByNameAsync(course.Name);

            if (cour != null)
            {
                throw new Exception($"Курса с названием {course.Name} уже существует");
            }

            await _courseRepository.AddAsync(course);
        }

        public async Task RemoveAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var pos = _courseRepository.GetByNameAsync(course.Name);

            if (pos == null)
            {
                throw new Exception($"Курса с названием {course.Name} не существует");
            }

            await _courseRepository.DeleteAsync(course);
        }

        public async Task UpdateAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var cour = _courseRepository.GetByNameAsync(course.Name);

            if (cour == null)
            {
                throw new Exception($"Курса с названием {course.Name} не существует");
            }

            await _courseRepository.UpdateAsync(course);
        }

        public async Task<List<Course>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses;
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"Идентификатор курса не может быть '{id}'");
            }

            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                throw new ArgumentNullException($"Идентификатора курса {id} не существует");
            }

            return course;
        }

        public async Task<Course> GetByNameAsync(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException($"Название курса не может быть '{name}'");
            }

            var course = await _courseRepository.GetByNameAsync(name);

            if (course == null)
            {
                throw new ArgumentNullException($"Курса с названием {name} не существует");
            }

            return course;
        }
    }
}
