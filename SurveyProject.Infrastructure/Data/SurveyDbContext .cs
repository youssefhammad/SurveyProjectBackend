using Azure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyProject.Core.Entities;
using Response = SurveyProject.Core.Entities.Response;

namespace SurveyProject.Infrastructure.Data
{
    public class SurveyDbContext : DbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
        {
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Survey)
                .HasForeignKey(q => q.SurveyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Respondents)
                .WithOne(r => r.Survey)
                .HasForeignKey(r => r.SurveyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuestionType>()
                .HasIndex(qt => qt.TypeName)
                .IsUnique();

            modelBuilder.Entity<QuestionType>()
                .HasMany(qt => qt.Questions)
                .WithOne(q => q.QuestionType)
                .HasForeignKey(q => q.QuestionTypeId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .Property(q => q.Order)
                .IsRequired();

            modelBuilder.Entity<Question>()
                .Property(q => q.Required)
                .HasDefaultValue(false);

            modelBuilder.Entity<Option>()
                .Property(o => o.Order)
                .IsRequired();

            modelBuilder.Entity<Respondent>()
                .HasMany(r => r.Responses)
                .WithOne(resp => resp.Respondent)
                .HasForeignKey(resp => resp.RespondentId)
                .OnDelete(DeleteBehavior.Cascade); 

            // Response
            modelBuilder.Entity<Response>()
                .HasOne(r => r.Option)
                .WithMany(o => o.Responses)
                .HasForeignKey(r => r.OptionId)
                .OnDelete(DeleteBehavior.SetNull); 

            modelBuilder.Entity<Response>()
                .HasOne(r => r.Question)
                .WithMany(q => q.Responses)
                .HasForeignKey(r => r.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Constraints: Ensure only one value field is populated
            modelBuilder.Entity<Response>()
    .HasCheckConstraint("CK_Response_OnlyOneValueTypeOrAllNull",
    @"(
        ([ValueText] IS NULL AND [ValueNumber] IS NULL AND [ValueBoolean] IS NULL AND [ValueDate] IS NULL AND [OptionId] IS NULL)
        OR
        ([ValueText] IS NOT NULL AND [ValueNumber] IS NULL AND [ValueBoolean] IS NULL AND [ValueDate] IS NULL AND [OptionId] IS NULL)
        OR
        ([ValueText] IS NULL AND [ValueNumber] IS NOT NULL AND [ValueBoolean] IS NULL AND [ValueDate] IS NULL AND [OptionId] IS NULL)
        OR
        ([ValueText] IS NULL AND [ValueNumber] IS NULL AND [ValueBoolean] IS NOT NULL AND [ValueDate] IS NULL AND [OptionId] IS NULL)
        OR
        ([ValueText] IS NULL AND [ValueNumber] IS NULL AND [ValueBoolean] IS NULL AND [ValueDate] IS NOT NULL AND [OptionId] IS NULL)
        OR
        ([ValueText] IS NULL AND [ValueNumber] IS NULL AND [ValueBoolean] IS NULL AND [ValueDate] IS NULL AND [OptionId] IS NOT NULL)
    )");
        }

        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity &&
                           (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}