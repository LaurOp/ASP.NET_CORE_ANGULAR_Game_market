using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class CreateReviewDTO
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
