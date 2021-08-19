using System;
using System.Collections.Generic;

#nullable disable

namespace Movie.BE.Models
{
    public partial class MovieGenre
    {
        public int IdMovie { get; set; }
        public int IdGenre { get; set; }

        public virtual Genre IdGenreNavigation { get; set; }
        public virtual Movie IdMovieNavigation { get; set; }
    }
}
