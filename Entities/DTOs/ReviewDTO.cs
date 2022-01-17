using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }

        public ReviewDTO(Review review)
        {
            this.Id = review.Id;
            this.Author = review.Author;
            this.Text = review.Text;
            this.likes = review.likes;
            this.dislikes = review.dislikes;
            this.GameId = review.GameId;
            this.Game = review.Game;
        }
    }
}
