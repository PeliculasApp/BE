using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Movie.BE.Models
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieActor> MovieActors { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=localhost; Database=Movies; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Background)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Background)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MovieActor");

                entity.HasOne(d => d.IdActorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdActor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MovieActor_actor_FK");

                entity.HasOne(d => d.IdMovieNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MovieActor_movie_FK");
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MovieGenre");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MovieGenre_Genre_FK");

                entity.HasOne(d => d.IdMovieNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MovieGenre_movie_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
