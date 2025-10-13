using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework1.Entities
{
    /// <summary>
    /// Сущность курс
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Идентификатор курса
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название курса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание курса
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Количество часов курса
        /// </summary>
        public int NumberOfHours { get; set; }

        //[Range(0, double.MaxValue, ErrorMessage = "Цена не может быть отрицательной!")]
        /// <summary>
        /// Стоимость курса
        /// </summary>
        public double Price { get; set; }

        #region Навигационные свойства
        public List<Course> Teachers { get; set; }

        public List<Course> Students { get; set; }

        public List<Course> Reviews { get; set; }
        #endregion 
    }
}
