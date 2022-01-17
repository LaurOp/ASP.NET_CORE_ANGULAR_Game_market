using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class CreatorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long NetWorth { get; set; }
        public int NumberOfEmployees { get; set; }
        public List<Game> Games { get; set; }

        public CreatorDTO(Creator creator)
        {
            this.Id = creator.Id;
            this.Name = creator.Name;
            this.NetWorth = creator.NetWorth;
            this.NumberOfEmployees = creator.NumberOfEmployees;
            this.Games = new List<Game>();
        }
    }
}
