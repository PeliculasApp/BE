using System;
using System.Collections.Generic;

#nullable disable

namespace Movie.BE.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Background { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
