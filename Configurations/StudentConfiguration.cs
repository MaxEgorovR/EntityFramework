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
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Свойства
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.MidleName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Mail)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.AdmissionDate)
                .IsRequired();

            builder.Property(s => s.CourseId)
                .IsRequired();

            // Связи
            builder.HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasPrincipalKey(c => c.Id)
                .HasForeignKey(s => s.CourseId);

            builder.HasMany(s => s.Reviews)
                .WithOne(r => r.Student)
                .HasPrincipalKey(s => s.Id)
                .HasForeignKey(r => r.StudentId);
        }
    }
}
