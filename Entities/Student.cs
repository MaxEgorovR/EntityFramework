using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework1.Entities
{
    /// <summary>
    /// Сущность студент
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Идентификатор студента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя студента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия сткдента
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество студента
        /// </summary>
        public string MidleName { get; set; }

        /// <summary>
        /// Почта студента
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Дата зачисления студента
        /// </summary>
        public DateTime AdmissionDate { get; set; }

        /// <summary>
        /// Идентификационный номер курса
        /// </summary>
        public int CourseId { get; set; }

        #region Навигационные свойства
        public Course Course { get; set; }

        public List<Course> Reviews { get; set; }
        #endregion
    }
}
