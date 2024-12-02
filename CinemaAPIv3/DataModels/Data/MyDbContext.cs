﻿using DataModels.Models.Domain;
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
        public MyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PostalCode > PostalCodes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USER
            ///////
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                      .HasMaxLength(50);
                entity.Property(e => e.LastName)
                      .HasMaxLength(50);
                entity.Property(e => e.Email)
                      .HasMaxLength(100);
                entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("GETDATE()");
            });

            // PostalCode   
            // We do not want identity on this PK
            modelBuilder.Entity<PostalCode>()
                .Property(e => e.PostalCodeId)
                .ValueGeneratedNever();

            // Movie
            modelBuilder.Entity<Movie>()
                .Property(e => e.Rating)
                .HasPrecision(3);

        }

    }
}
