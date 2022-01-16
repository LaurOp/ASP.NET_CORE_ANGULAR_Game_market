using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int MinimumAge { get; set; }
        public int Purchases { get; set; }
        public float Grade { get; set; }//out of 10
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public Storyline Storyline { get; set; }
        public ICollection<GameGenre> GameGenres { get; set; }
    }
}
