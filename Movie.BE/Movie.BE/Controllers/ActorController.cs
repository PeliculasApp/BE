using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.BE.DAL;
using Movie.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly MoviesContext _db;
        private readonly ActorDAL _dal;
        public ActorController(MoviesContext db)
        {
            _dal = new ActorDAL(db);
        }
        /// <summary>
        /// Obtiene todos los actores de la pelicula
        /// </summary>
        [HttpGet("{idMovie}/Movie")]
        public async Task<IActionResult> GetActorsByIdMovie(int idMovie)
        {
            var items = await _dal.GetActorsByIdMovie(idMovie);
            return Ok(items);
        }
    }
}