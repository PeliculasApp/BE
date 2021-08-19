using Microsoft.EntityFrameworkCore;
using Movie.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.BE.DAL
{
    internal class ActorDAL: DAL
    {
        internal ActorDAL(MoviesContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Obtiene todos los actores de la pelicula
        /// </summary>
        internal async Task<List<Actor>> GetActorsByIdMovie(int idMovie)
        {
            List<Actor> items = new List<Actor>();
            return await (from a in _db.Actors
                           join am in _db.MovieActors on a.Id equals am.IdActor
                           join m in _db.Movies on am.IdMovie equals m.Id
                           where m.Id == idMovie
                           select a).ToListAsync();
        }
    }
}