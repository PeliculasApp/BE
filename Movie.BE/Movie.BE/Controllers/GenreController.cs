using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.BE.Controllers
{
    /// <summary>
    /// Generos controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly MoviesContext _db;
        /// <summary>
        /// Constructor
        /// </summary>
        public GenreController(MoviesContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Obtiene todos los generos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            object result = null;
            using (MoviesContext context = new MoviesContext())
            {
                result = await (from ge in context.Genres
                             select ge).ToListAsync();
            }
                
            return Ok(result);
        }
    }
}