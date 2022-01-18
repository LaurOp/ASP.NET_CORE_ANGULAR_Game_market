using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2ProjectWeb.Entities;

namespace Proiect.Entities.DTOs
{
    public interface ITokenManager
    {
        Task<string> CreateToken(User user);
    }
}
