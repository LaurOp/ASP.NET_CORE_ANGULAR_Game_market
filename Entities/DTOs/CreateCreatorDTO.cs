using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class CreateCreatorDTO
    {
        public string Name { get; set; }
        public long NetWorth { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}
