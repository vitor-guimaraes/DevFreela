using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Project>()
                    .HasKey(p => p.Id);
                    //.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();

            modelBuilder.Entity<Project>()
                    .HasOne(p => p.Freelancer)
                    .WithMany(f => f.FreelanceProjects)
                    .HasForeignKey(p => p.IdFreelancer)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                    .HasOne(p => p.Client)
                    .WithMany(f => f.OwnedProjects)
                    .HasForeignKey(p => p.IdClient)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
                    .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
                    .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                    .HasMany(u => u.Skills)
                    .WithOne()
                    .HasForeignKey(u => u.IdSkill)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSkill>()
                    .HasKey(u => u.Id);
        }
    }
}
