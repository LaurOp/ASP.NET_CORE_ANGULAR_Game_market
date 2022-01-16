using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Creator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long NetWorth { get; set; }
        public int NumberOfEmployees { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
