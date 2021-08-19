using Microsoft.EntityFrameworkCore;
using Movie.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.BE.DAL
{
    internal class MovieDAL : DAL
    {
        internal MovieDAL(MoviesContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Obtienes las peliculas por el actor
        /// </summary>
        internal async Task<List<Models.Movie>> GetMoviesByIdActor(int idActor)
        {
            return await (from m in _db.Movies
                          join ma in _db.MovieActors on m.Id equals ma.IdMovie
                          join a in _db.Actors on ma.IdActor equals a.Id
                          where a.Id == idActor
                          select new Models.Movie
                          {
                              Id = m.Id,
                              Name = m.Name,
                              Description = m.Description,
                              Background = m.Background,
                              Genres = new GenreDAL(_db).GetGenreByIdMovie(m.Id)
                              //Genres = (from g in _db.Genres
                              //          join mg in _db.MovieGenres on g.Id equals mg.IdGenre
                              //          where mg.IdMovie == m.Id
                              //          //group g by g.Id, g.Name into dta
                              //          select g).ToList()
                          }).ToListAsync();
        }
    }
}