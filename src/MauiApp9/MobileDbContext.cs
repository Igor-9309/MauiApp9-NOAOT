using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace MauiApp9
{
    public class MobileDbContext(DbContextOptions dbOptions) : DbContext(dbOptions)
    {
        public DbSet<ProjectEntity> Projects { get; set; }

        protected sealed override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    public class ProjectEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class ProjectConfig : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Name).HasMaxLength(120);
        }
    }
}
