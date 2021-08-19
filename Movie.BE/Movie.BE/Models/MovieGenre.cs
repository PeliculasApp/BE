///Developer: Eduardo Gonzalez
///CreateDate: 19/08/2020
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Movie.BE.Models
{
    /// <summary>
    /// Peliculas-Genero Model
    /// </summary>
    [Keyless]
    public class MovieGenreModel
    {
        /// <summary>
        /// Id pelicula
        /// </summary>
        [Required]
        [ForeignKey("MovieGenre_movie_FK")]
        public int IdMovie { get; set; }
        /// <summary>
        /// Id genero
        /// </summary>
        [Required]
        [ForeignKey("MovieGenre_Genre_FK")]
        public int IdGenre { get; set; }
    }
}