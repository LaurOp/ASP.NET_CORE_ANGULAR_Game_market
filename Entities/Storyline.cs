using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Storyline
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Playtime { get; set; } //in hours
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
