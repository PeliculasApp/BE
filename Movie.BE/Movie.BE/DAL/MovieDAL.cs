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
    /// Peliculas DAL
    /// </summary>
    internal class MovieDAL : DAL
    {
        /// <summary>
        /// Constructor
        /// </summary>
        internal MovieDAL(MoviesContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Obtienes las peliculas por el actor
        /// </summary>
        internal async Task<List<Models.MovieModel>> GetMoviesByIdActor(int idActor)
        {
            using (_db)
            {
                var items = await (from mo in _db.Movie
                                   join ma in _db.MovieActor on mo.Id equals ma.IdMovie
                                   join a in _db.Actor on ma.IdActor equals a.Id
                                   where a.Id == idActor
                                   orderby mo.Name descending
                                   select new Models.MovieModel
                                   {
                                       Id = mo.Id,
                                       Name = mo.Name,
                                       Description = mo.Description,
                                       Background = mo.Background
                                   }).ToListAsync();
                // Obtiene los generos de la pelicula
                GetGenresByMovie(ref items);
                // Obtiene los actores de la pelicula
                GetActorByMovie(ref items);
                return items;
            }
        }
        /// <summary>
        /// Obtiene la pelicula por id
        /// </summary>
        internal async Task<MovieModel> GetMovieByIdMovie(int idMovie)
        {
            using (_db)
            {
                var items = await (from mo in _db.Movie
                                   where mo.Id == idMovie
                                   orderby mo.Name descending
                                   select new Models.MovieModel
                                   {
                                       Id = mo.Id,
                                       Name = mo.Name,
                                       Description = mo.Description,
                                       Background = mo.Background
                                   }).ToListAsync();
                // Obtiene los generos de la pelicula
                GetGenresByMovie(ref items);
                // Obtiene los actores de la pelicula
                GetActorByMovie(ref items);
                return items.FirstOrDefault();
            }
        }
        ///// <summary>
        ///// Busca peliculas por actor
        ///// </summary>
        //internal async Task<List<Models.MovieModel>> GetMoviesByNameActor(string actorName)
        //{
        //    using (_db)
        //    {
        //        return await (from m in _db.Movie
        //                      join ma in _db.MovieActor on m.Id equals ma.IdMovie
        //                      join a in _db.Actor on ma.IdActor equals a.Id
        //                      where a.Name.ToUpper().Contains(actorName.ToUpper())
        //                      select m
        //                        ).ToListAsync();
        //    }
        //}
        /// <summary>
        /// Busca peliculas por titulo
        /// </summary>
        internal async Task<List<Models.MovieModel>> GetMoviesByTitle(string title)
        {
            using (_db)
            {
                var items = await (from m in _db.Movie
                                   where m.Name.ToUpper().Contains(title.ToUpper())
                                   select new Models.MovieModel
                                   {
                                       Id = m.Id,
                                       Name = m.Name,
                                       Background = m.Background,
                                       Description = m.Description
                                   }).ToListAsync();
                // Obtiene los generos de la pelicula
                GetGenresByMovie(ref items);
                // Obtiene los actores de la pelicula
                GetActorByMovie(ref items);
                return items;
            }
        }
        /// <summary>
        /// Obtiene los generos de la pelicula
        /// </summary>
        private void GetGenresByMovie(ref List<Models.MovieModel> model)
        {
            foreach (var item in model)
            {
                item.Genres = (from g in _db.Genre
                               join mg in _db.MovieGenre on g.Id equals mg.IdGenre
                               where mg.IdMovie == item.Id
                               select new Models.GenreModel
                               {
                                   Id = g.Id,
                                   Name = g.Name
                               }).ToList();
            }
        }
        /// <summary>
        /// Obtiene los actores de la pelicula
        /// </summary>
        private void GetActorByMovie(ref List<Models.MovieModel> model)
        {
            foreach (var item in model)
            {
                item.Actors = (from a in _db.Actor
                               join ma in _db.MovieActor on a.Id equals ma.IdActor
                               where ma.IdMovie == item.Id
                               select new Models.ActorModel
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                                   Background = a.Background
                               }).ToList();
            }
        }
    }
}