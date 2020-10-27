using PinArt.Core.Entities;
using PinArt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinArt.Core.Services
{
    public class ArtistaService : IArtistaService
    {
        private readonly IUnitOfWork _UoW;

        public ArtistaService(IUnitOfWork unitOfWork)
        {
            _UoW = unitOfWork;            
        }

        public async Task<IEnumerable<Artista>> GetArtistas()
        {
            var Artistas = await _UoW.Artistas.GetAll();

            return Artistas;
        }

        public async Task<Artista> GetArtista(int id)
        {
            return await _UoW.Artistas.GetById(id);
        }

        public async Task InsertArtista(Artista artista)
        {
            _UoW.Artistas.Add(artista);
            await _UoW.CompleteAsync();
        }

        public async Task UpdateArtista(Artista artista)
        {
            _UoW.Artistas.Update(artista);
            await _UoW.CompleteAsync();
        }

        public async Task<bool> DeleteArtista(Artista artista)
        {
            _UoW.Artistas.Remove(artista);
            await _UoW.CompleteAsync();
            return true;
        }
    }
}
