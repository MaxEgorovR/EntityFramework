using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Entities;
using EntityFramework1.Repositories;

namespace EntityFramework1.Services
{
    public class TeacherService
    {
        private readonly TeacherRepository _teacherRepository;

        public TeacherService(OnlineСoursesContext db)
        {
            _teacherRepository = new TeacherRepository(db);
        }

        public async Task AddAsync(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            var teach = _teacherRepository.GetByIdAsync(teacher.Id);

            if (teach != null)
            {
                throw new Exception($"Преподаватель с идентификатором {teacher.Id} уже существует");
            }

            await _teacherRepository.AddAsync(teacher);
        }

        public async Task RemoveAsync(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            var teach = _teacherRepository.GetByIdAsync(teacher.Id);

            if (teach == null)
            {
                throw new Exception($"Преподавателя с идентификатором {teacher.Id} не существует");
            }

            await _teacherRepository.DeleteAsync(teacher);
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            var teach = _teacherRepository.GetByIdAsync(teacher.Id);

            if (teach == null)
            {
                throw new Exception($"Преподавателя с идентификатором {teacher.Id} не существует");
            }

            await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return teachers;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"Идентификатор преподавателя не может быть '{id}'");
            }

            var teacher = await _teacherRepository.GetByIdAsync(id);

            if (teacher == null)
            {
                throw new ArgumentNullException($"Идентификатора преподавателя {id} не существует");
            }

            return teacher;
        }

        public async Task<Teacher> GetByNameAsync(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException($"Имя преподавателя не может быть '{name}'");
            }

            var course = await _teacherRepository.GetByNameAsync(name);

            if (course == null)
            {
                throw new ArgumentNullException($"преподавателя с именем {name} не существует");
            }

            return course;
        }
    }
}
