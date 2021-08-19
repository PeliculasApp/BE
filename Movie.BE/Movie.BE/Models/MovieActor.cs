///Developer: Eduardo Gonzalez
///CreateDate: 19/08/2020
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Movie.BE.Models
{
    /// <summary>
    /// Pelicula-Actor model
    /// </summary>
    [Keyless]
    public class MovieActorModel
    {
        /// <summary>
        /// Id pelicula
        /// </summary>
        [Required]
        [ForeignKey("MovieActor_movie_FK")]
        public int IdMovie { get; set; }
        /// <summary>
        /// Id actor
        /// </summary>
        [Required]
        [ForeignKey("MovieActor_actor_FK")]
        public int IdActor { get; set; }
    }
}