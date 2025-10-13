using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Entities;
using EntityFramework1.Repositories;

namespace EntityFramework1.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService(OnlineСoursesContext db)
        {
            _studentRepository = new StudentRepository(db);
        }

        public async Task AddAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var stud = _studentRepository.GetByIdAsync(student.Id);

            if (stud != null)
            {
                throw new Exception($"Студент с идентификатором {student.Id} уже существует");
            }

            await _studentRepository.AddAsync(student);
        }

        public async Task RemoveAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var stud = _studentRepository.GetByIdAsync(student.Id);

            if (stud == null)
            {
                throw new Exception($"Студента с идентификатором {student.Id} не существует");
            }

            await _studentRepository.DeleteAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var stud = _studentRepository.GetByIdAsync(student.Id);

            if (stud == null)
            {
                throw new Exception($"Студента с идентификатором {student.Id} не существует");
            }

            await _studentRepository.UpdateAsync(student);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"Идентификатор студента не может быть '{id}'");
            }

            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                throw new ArgumentNullException($"Идентификатора студента {id} не существует");
            }

            return student;
        }

        public async Task<Student> GetByNameAsync(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException($"Имя студента не может быть '{name}'");
            }

            var teacher = await _studentRepository.GetByNameAsync(name);

            if (teacher == null)
            {
                throw new ArgumentNullException($"студента с Именем {name} не существует");
            }

            return teacher;
        }
    }
}
