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
    public class ReviewConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Свойства
            builder.HasKey(r => r.Id);

            builder.Property(r => r.CourseId)
                .IsRequired();

            builder.Property(r => r.StudentId)
                .IsRequired();

            builder.Property(r => r.Rating)
                .IsRequired();

            builder.Property(r => r.Comment)
                .IsRequired()
                .HasMaxLength(100);

            // Связи
            builder.HasOne(r => r.Course)
                .WithMany(c => c.Reviews);

            builder.HasOne(r => r.Student)
                .WithMany(s => s.Reviews);
        }
    }
}
