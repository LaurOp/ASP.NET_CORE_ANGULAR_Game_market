using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class CreateStorylineDTO
    {
        public string Text { get; set; }
        public int Playtime { get; set; } //in hours
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
