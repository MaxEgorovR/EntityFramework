using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework1
{
    /// <summary>
    /// Контекст Онлайн курсы
    /// </summary>
    public class OnlineСoursesContext : DbContext
    {
        /// <summary>
        /// Таблица курсов
        /// </summary>
        public List<Course> Courses { get; set; }

        /// <summary>
        /// Таблица отзывов
        /// </summary>
        public List<Review> Reviews { get; set; }

        /// <summary>
        /// Таблица студентов
        /// </summary>
        public List<Student> Students { get; set; }

        /// <summary>
        /// Таблица пркподавателей
        /// </summary>
        public List<Teacher> Teachers { get; set; }

        private readonly string _connString = "Server=MyServerAddress;Database=OnlineCoursesDb;Trusted_Connection=True;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }
    }
}
