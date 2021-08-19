///Developer: Eduardo Gonzalez
///CreateDate: 19/08/2020
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Movie.BE.Models
{
    /// <summary>
    /// Genero model
    /// </summary>
    public class GenreModel
    {
        /// <summary>
        /// Id genero
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// nombre genero
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}