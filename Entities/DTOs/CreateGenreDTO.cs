using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class CreateGenreDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ForKids { get; set; }
    }
}
