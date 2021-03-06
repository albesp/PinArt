﻿using Microsoft.EntityFrameworkCore;
using PinArt.Core.Entities;
using PinArt.Core.Interfaces;
using PinArt.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PinArt.Infrastructure.Repositories
{
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly PinArtDbContext _context;

        public ArtistaRepository(PinArtDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artista>> GetAll()
        {
            var artistas = _context.Artistas.AsNoTracking()
                                            .Include(a => a.Pais)
                                            .Include(a => a.Obras)
                                            .ThenInclude(o => o.Tecnica)
                                            .Include(a => a.ArtistasEstilos)
                                            .ThenInclude(ae => ae.Estilo);

            return await artistas.ToListAsync();
        }
        public async Task<Artista> GetById(int id)
        {
            return await _context.Artistas.Include(a => a.Pais)
                                          .Include(a => a.Obras)
                                          .ThenInclude(o => o.Tecnica)
                                          .Include(a => a.ArtistasEstilos)
                                          .ThenInclude(ae => ae.Estilo)
                                          .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Artista artista)
        {
            _context.Artistas.Add(artista);
        }

        public void Update(Artista artista)
        {
            _context.Artistas.Update(artista);

        }

        public void Remove(Artista artista)
        {
            _context.Artistas.Remove(artista);
        }
    }
}
