using PinArt.Core.Entities;
using PinArt.Core.Interfaces;
using PinArt.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PinArt.Infrastructure.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly PinArtDbContext _context;

        public PaisRepository(PinArtDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pais>> GetAll()
        {
            var paises = _context.Paises.AsNoTracking();

            return await paises.ToListAsync();
        }

    }
}
