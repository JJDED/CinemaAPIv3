using DataModels.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Data
{
    public class MyDbContext : DbContext
    {
        private readonly DbContextOptions dbContextOptions;
        
        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostalCodeModel> PostalCodes { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<AddressModel> Address { get; set; }
        public DbSet<TheaterModel> Theaters { get; set; }
        public DbSet<HallModel> Hall { get; set; }
        public DbSet<SeatModel> Seat { get; set; }
        public DbSet<ShowtimesModel> Showtimes { get; set; }
        public DbSet<TicketsModel> Tickets { get; set; }

        // Fluent API
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=D4TECH16\\SQLEXPRESS;Database=CinemaDBv3;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostalCodeModel>().Property(a => a.Id).ValueGeneratedNever();

            // Configure many-to-many relationship
            modelBuilder.Entity<MovieGenre>(mg =>
            {
                mg.HasKey(x => new { x.MovieId, x.GenreId });

                mg.HasOne(x => x.Movie)
                    .WithMany(m => m.MovieGenres)
                    .HasForeignKey(x => x.MovieId);

                mg.HasOne(x => x.Genre)
                    .WithMany(g => g.MovieGenres)
                    .HasForeignKey(x => x.GenreId);
            });
        }

    }    
}
