using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework1.Entities
{
    /// <summary>
    /// Сущность преподаватель
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Идентификатор преподавателя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя преподавателя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия преподавателя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество преподавателя
        /// </summary>
        public string MidleName { get; set; }

        /// <summary>
        /// Идентификационный номер курса
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Почта преподавателя
        /// </summary>
        public string Mail {  get; set; }

        /// <summary>
        /// Телефон преподавателя
        /// </summary>
        public string Phone { get; set; }

        #region Навигационные свойства
        public Course Course { get; set; }
        #endregion
    }
}
