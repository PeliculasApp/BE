///Developer: Eduardo Gonzalez
///CreateDate: 19/08/2020
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Movie.BE.Models
{
    /// <summary>
    /// Peliculas Model
    /// </summary>
    public class MovieModel
    {
        /// <summary>
        /// Id pelicula
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nombre pelicula
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Fondo
        /// </summary>
        [Required]
        public string Background { get; set; }
        /// <summary>
        /// Generos
        /// </summary>
        public List<GenreModel> Genres { get; set; }
        /// <summary>
        /// Actores
        /// </summary>
        public List<ActorModel> Actors { get; set; }
    }
}