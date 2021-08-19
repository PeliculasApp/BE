using System;
using System.Collections.Generic;

#nullable disable

namespace Movie.BE.Models
{
    public partial class MovieActor
    {
        public int IdMovie { get; set; }
        public int IdActor { get; set; }

        public virtual Actor IdActorNavigation { get; set; }
        public virtual Movie IdMovieNavigation { get; set; }
    }
}
