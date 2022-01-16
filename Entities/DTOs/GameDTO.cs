using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int MinimumAge { get; set; }
        public int Purchases { get; set; }
        public float Grade { get; set; }//out of 10
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
        public List<Review> Reviews { get; set; }
        public Storyline Storyline { get; set; }
        public List<GameGenre> GameGenres { get; set; }

        public GameDTO(Game game)
        {
            this.Id = game.Id;
            this.Name = game.Name;
            this.Price = game.Price;
            this.MinimumAge = game.MinimumAge;
            this.Purchases = game.Purchases;
            this.Grade = game.Grade;
            this.CreatorId = game.CreatorId;
            this.Creator = game.Creator;
            this.Storyline = game.Storyline;
            this.Reviews = new List<Review>();
            this.GameGenres = new List<GameGenre>();

        }
    }
}
