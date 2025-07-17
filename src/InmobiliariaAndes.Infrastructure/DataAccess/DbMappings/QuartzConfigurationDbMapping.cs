using InmobiliariaAndes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaAndes.Infrastructure.DataAccess.DbMappings;

public static class QuartzConfigurationDbMapping
{
    public static void Map(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuartzConfiguration>(entity =>
        {
            entity.ToTable("quartz_configurations");

            entity.HasKey(q => q.Id);

            entity.Property(q => q.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd(); // Assuming Id is a long and auto-incremented

            entity.Property(q => q.CreatedAt)
                .HasColumnName("created_at")                
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(q => q.UpdatedAt)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(q => q.Description)
                .HasColumnName("description");

            entity.Property(q => q.IsEnabled)
                .HasColumnName("is_enabled");

            entity.Property(q => q.CronExpression)
            .HasColumnName("cron_expression")
            .IsRequired()
            .HasMaxLength(255);

            entity.Property(q => q.JobName)
            .HasColumnName("job_name")
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(q => q.JobGroup)
            .HasColumnName("job_group")
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(q => q.TriggerName)
                .HasColumnName("trigger_name")
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(q => q.ClassServiceName)
                .HasColumnName("class_service_name")
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(q => q.Name)
                .HasColumnName("name")
                .IsRequired();
        });
    }
}
