using Microsoft.EntityFrameworkCore;
using Movie.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.BE.DAL
{
    internal class GenreDAL : DAL
    {
        internal GenreDAL(MoviesContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Obtiene todos los generos
        /// </summary>
        internal async Task<List<Models.Genre>> Get()
        {
            return await (from g in _db.Genres
                          select g).ToListAsync();
        }
        internal List<Genre> GetGenreByIdMovie(int idMovie)
        {
            return (from g in _db.Genres
                    join mg in _db.MovieGenres on g.Id equals mg.IdMovie
                    select g).ToList();
        }
    }
}