using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class CreateGameDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int MinimumAge { get; set; }
        public int Purchases { get; set; }
        public float Grade { get; set; }
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
        public Storyline Storyline { get; set; }
    }
}
