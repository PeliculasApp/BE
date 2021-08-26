///Developer: Eduardo Gonzalez
///CreateDate: 19/08/2020
using Microsoft.AspNetCore.Mvc;
using Movie.BE.DAL;
using Movie.BE.Models;
using System.Threading.Tasks;
namespace Movie.BE.Controllers
{
    /// <summary>
    /// Peliculas controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        /// <summary>
        /// Peliculas dal
        /// </summary>
        private readonly MovieDAL _dal;
        /// <summary>
        /// Constructor
        /// </summary>
        public MovieController(MoviesContext db)
        {
            _dal = new MovieDAL(db);
        }
        /// <summary>
        /// Obtienes las peliculas por el actor
        /// </summary>
        [HttpGet("{idActor}/Actor")]
        public async Task<IActionResult> GetMoviesByIdActor(int idActor)
        {
            var items = await _dal.GetMoviesByIdActor(idActor);
            return Ok(items);
        }
        /// <summary>
        /// Obtienes las peliculas por titulo
        /// </summary>
        [HttpGet("{title}/Title")]
        public async Task<IActionResult> GetMoviesByTitle(string title)
        {
            var items = await _dal.GetMoviesByTitle(title);
            return Ok(items);
        }
        /// <summary>
        /// Obtiene la pelicula por id
        /// </summary>
        [HttpGet("{idMovie}")]
        public async Task<IActionResult> GetMovieByIdMovie(int idMovie)
        {
            var items = await _dal.GetMovieByIdMovie(idMovie);
            return Ok(items);
        }        
    }
}