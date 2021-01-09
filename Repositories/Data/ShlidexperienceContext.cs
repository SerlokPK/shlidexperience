using DomainModels.Slides;
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

        public DbSet<OptionResultEntity> OptionResults { get; set; }

        public DbSet<DeviceEntity> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideTypeEntity>()
                        .HasData(new SlideTypeEntity { SlideTypeId = 1, Type = SlideType.MultipleChoice },
                                 new SlideTypeEntity { SlideTypeId = 2, Type = SlideType.ReactionQuestion });

            modelBuilder.Entity<OptionResultEntity>()
                .HasKey(c => new { c.SlideId, c.SlideOptionId, c.DeviceId });
            modelBuilder.Entity<OptionResultEntity>()
                .HasOne(o => o.SlideOption)
                .WithMany(x => x.OptionResults)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SlideOptionEntity>()
                .Property(x => x.SlideOptionId)
                .ValueGeneratedNever();
        }
    }
}
