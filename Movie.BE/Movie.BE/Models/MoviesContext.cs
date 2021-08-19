///Developer: Eduardo Gonzalez
///CreateDate: 19/08/2020
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Movie.BE.Models
{
    /// <summary>
    /// Contexto peliculas
    /// </summary>
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }
        public MoviesContext(DbContextOptions<MoviesContext> options)   : base(options)
        {
        }
        public DbSet<ActorModel> Actor { get; set; }
        public DbSet<GenreModel> Genre { get; set; }
        public DbSet<MovieModel> Movie { get; set; }
        public DbSet<MovieActorModel> MovieActor { get; set; }
        public DbSet<MovieGenreModel> MovieGenre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
    }
}