///Developer: Eduardo Gonzalez
///CreateDate: 19/08/2020
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
    /// <summary>
    /// Actor controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        /// <summary>
        /// Actor dal
        /// </summary>
        private readonly ActorDAL _dal;
        /// <summary>
        /// Contructor
        /// </summary>
        public ActorController(MoviesContext db)
        {
            _dal = new ActorDAL(db);
            // RAMA ET1 DEV BRANCS
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
        /// <summary>
        /// Obtiene actores con el nombre
        /// </summary>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetActorByName(string name)
        {
            var items = await _dal.GetActorByName(name);
            return Ok(items);
        }
    }
}