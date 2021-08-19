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
    /// Generos controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        /// <summary>
        /// Genero dal
        /// </summary>
        private readonly GenreDAL _dal;
        /// <summary>
        /// Constructor
        /// </summary>
        public GenreController(MoviesContext db)
        {
            _dal = new GenreDAL(db);
        }
        /// <summary>
        /// Obtiene todos los generos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<GenreModel> result = await _dal.Get();
            return Ok(result);
        }
    }
}