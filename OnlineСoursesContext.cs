using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Configurations;
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
        public List<Course> Reviews { get; set; }

        /// <summary>
        /// Таблица студентов
        /// </summary>
        public List<Course> Students { get; set; }

        /// <summary>
        /// Таблица пркподавателей
        /// </summary>
        public List<Course> Teachers { get; set; }

        private readonly string _connString = "Server=TRUEMALPREM\\SQLEXPRESS;Database=OnlineCoursesDb;Trusted_Connection=True;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        }
    }
}
