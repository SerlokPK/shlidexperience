using Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Data
{
    public class ShlidexperienceContext : DbContext
    {
        public ShlidexperienceContext(DbContextOptions<ShlidexperienceContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<PresentationEntity> Presentations { get; set; }

        public DbSet<SlideEntity> Slides { get; set; }

        public DbSet<SlideTypeEntity> SlideTypes { get; set; }

        public DbSet<SlideOptionEntity> SlideOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideTypeEntity>()
                        .HasData(new SlideTypeEntity { SlideTypeId = 1, Type = SlideType.MultipleChoice },
                                 new SlideTypeEntity { SlideTypeId = 2, Type = SlideType.ReactionQuestion });
        }
    }
}
