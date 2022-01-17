using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class StorylineDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Playtime { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }

        public StorylineDTO(Storyline storyline)
        {
            this.Id = storyline.Id;
            this.Text = storyline.Text;
            this.Playtime = storyline.Playtime;
            this.GameId = storyline.GameId;
            this.Game = storyline.Game;
        }
    }
}
