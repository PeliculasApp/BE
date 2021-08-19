///Developer: Eduardo Gonzalez
///CreateDate: 19/08/2020
using Microsoft.EntityFrameworkCore;
using Movie.BE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.BE.DAL
{
    /// <summary>
    /// Genero dal
    /// </summary>
    internal class GenreDAL : DAL
    {
        /// <summary>
        /// Constructor
        /// </summary>
        internal GenreDAL(MoviesContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Obtiene todos los generos
        /// </summary>
        internal async Task<List<GenreModel>> Get()
        {
            return await (from g in _db.Genre
                          select new GenreModel
                          { 
                            Id = g.Id,
                            Name = g.Name
                          }).ToListAsync();
        }
    }
}