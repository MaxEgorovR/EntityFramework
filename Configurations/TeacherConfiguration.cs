using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework1.Configurations
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Свойства
            builder.HasKey(t  => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.MidleName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.CourseId)
                .IsRequired();

            builder.Property(t => t.Mail)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(100);

            // Связи
            builder.HasOne(t => t.Course)
                .WithMany(c => c.Teachers)
                .HasPrincipalKey(c => c.Id)
                .HasForeignKey(t => t.CourseId);
        }
    }
}
