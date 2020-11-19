using PinArt.Core.Interfaces;
using PinArt.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinArt.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PinArtDbContext _context;
        private readonly IArtistaRepository _artistaRepository;
        private readonly IPaisRepository _paisRepository;


        public UnitOfWork(PinArtDbContext context)
        {
          this._context = context;
        }

         public IArtistaRepository Artistas => _artistaRepository ?? new ArtistaRepository(_context);
         public IPaisRepository Paises => _paisRepository ?? new PaisRepository(_context);

        public async Task CompleteAsync()
         {
               await _context.SaveChangesAsync();
         }
    }
}
