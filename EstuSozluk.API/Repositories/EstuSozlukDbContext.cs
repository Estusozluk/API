using EstuSozluk.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EstuSozluk.API.Repositories
{
    public class EstuSozlukDbContext : DbContext
    {

        public EstuSozlukDbContext(DbContextOptions<EstuSozlukDbContext> options)
        : base(options)
        {

        }

        //ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        //{
        //    builder
        //    .AddConsole((options) => { })
        //    .AddFilter((category, level) =>
        //        category == DbLoggerCategory.Database.Command.Name
        // && level == LogLevel.Information);
        //});

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseMySQL(_Configuration["ConnectionString:Default"]);
        //    options.UseLoggerFactory(_loggerFactory);
        //}


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(c => c.Entries)
                .WithOne(s => s.User)
                .HasConstraintName("FK_EntryUser")
                .HasForeignKey(d => d.entryuser)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Followships>().HasKey(i => new { i.follower, i.followed });

            modelBuilder.Entity<Followships>()
                .HasOne(c => c.User1)
                .WithMany(s => s.Following)
                .HasForeignKey(k => k.follower);

            modelBuilder.Entity<Followships>()
                .HasOne(c => c.User2)
                .WithMany(s => s.Followed)
                .HasForeignKey(k => k.followed);




        }

        public DbSet<Followships> Followships { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entries { get; set; }

    }
}
