using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie.BE.DAL;
using Movie.BE.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MoviesContext _db;
        private readonly MovieDAL _dal;
        public MovieController(MoviesContext db)
        {
            _dal = new MovieDAL(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allMovies = _db.Movies.ToList();

            return Ok(allMovies);
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
    }
}
