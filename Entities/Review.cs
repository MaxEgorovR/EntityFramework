using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework1.Entities
{
    /// <summary>
    /// Сущность отзыв
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Идентификатор отзыва
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер курса
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Идентификационный номер студента
        /// </summary>
        public int StudentId { get; set; }

        [Range(0, 100, ErrorMessage = "Рейтинг не может быть отрицательным или превышать 100!")]
        /// <summary>
        /// Рейтинг отзыва
        /// </summary>
        public int Rating {  get; set; }

        /// <summary>
        /// Комментарий к отзыву
        /// </summary>
        public string Comment { get; set; }

        #region Навигационные свойства
        public Course Course { get; set; }

        public Student Student { get; set; }
        #endregion
    }
}
