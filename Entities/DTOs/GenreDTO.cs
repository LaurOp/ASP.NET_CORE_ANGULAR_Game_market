using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ForKids { get; set; }
        public List<GameGenre> GameGenres { get; set; }

        public GenreDTO(Genre genre)
        {
            this.Id = genre.Id;
            this.Name = genre.Name;
            this.Description = genre.Description;
            this.ForKids = genre.ForKids;
            this.GameGenres = new List<GameGenre>();
        }
    }
}
