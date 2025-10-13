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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Свойства
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.NumberOfHours)
                .IsRequired();

            builder.Property(c => c.Price)
                .IsRequired();

            // Связи
            builder.HasMany(c => c.Students)
                .WithOne(s => s.Course)
                .HasPrincipalKey((System.Linq.Expressions.Expression<Func<Course, object?>>)(c => c.Id))
                .HasForeignKey(s => s.CourseId);

            builder.HasMany(c => c.Teachers)
                .WithOne(t => t.Course)
                .HasPrincipalKey((System.Linq.Expressions.Expression<Func<Course, object?>>)(c => c.Id))
                .HasForeignKey(t => t.CourseId);

            builder.HasMany(c => c.Reviews)
                .WithOne(r => r.Course)
                .HasPrincipalKey(c => c.Id)
                .HasForeignKey(r => r.CourseId);
        }
    }
}
