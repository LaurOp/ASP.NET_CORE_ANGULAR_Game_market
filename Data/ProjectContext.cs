using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect.Entities;

namespace Proiect.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) {}

        public DbSet<Game> Games { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Storyline> Storylines { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Storyline)
                .WithOne(s => s.Game);

            modelBuilder.Entity<Creator>()
                .HasMany(c => c.Games)
                .WithOne(g => g.Creator);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Reviews)
                .WithOne(g => g.Game);


            modelBuilder.Entity<GameGenre>().HasKey(gg => new {gg.GameId, gg.GenreId});

            modelBuilder.Entity<GameGenre>()
                .HasOne(gg => gg.Game)
                .WithMany(g => g.GameGenres)
                .HasForeignKey(gg => gg.GameId);

            modelBuilder.Entity<GameGenre>()
                .HasOne(gg => gg.Genre)
                .WithMany(g => g.GameGenres)
                .HasForeignKey(gg => gg.GenreId);



            base.OnModelCreating(modelBuilder);
        }
    }
}
