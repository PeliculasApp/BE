///Developer: Eduardo Gonzalez
///CreateDate: 19/08/2020
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Movie.BE.Models
{
    /// <summary>
    /// Actor model
    /// </summary>
    public class ActorModel
    {
        /// <summary>
        /// Id actor
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nombre actor
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Fondo
        /// </summary>
        [Required]
        public string Background { get; set; }
    }
}