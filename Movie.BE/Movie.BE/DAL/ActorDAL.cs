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
    /// Actor DAL
    /// </summary>
    internal class ActorDAL : DAL
    {
        /// <summary>
        /// Constructor
        /// </summary>
        internal ActorDAL(MoviesContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Obtiene todos los actores de la pelicula
        /// </summary>
        internal async Task<List<ActorModel>> GetActorsByIdMovie(int idMovie)
        {
            List<ActorModel> items = new List<ActorModel>();
            return await (from a in _db.Actor
                          join am in _db.MovieActor on a.Id equals am.IdActor
                          join m in _db.Movie on am.IdMovie equals m.Id
                          where m.Id == idMovie
                          select a).ToListAsync();
        }
        /// <summary>
        /// Obtiene actores con el nombre
        /// </summary>
        internal async Task<List<ActorModel>> GetActorByName(string name)
        {
            return await (from a in _db.Actor
                          where a.Name.ToUpper().Contains(name.ToUpper())
                          select new ActorModel
                          {
                              Id = a.Id,
                              Name = a.Name,
                              Background = a.Background
                          }).ToListAsync();
        }
    }
}