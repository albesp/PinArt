using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinArt.Core.Interfaces
{
    public interface IArtistaService
    {
        Task<IEnumerable<Artista>> GetArtistas();

        Task<Artista> GetArtista(int id);

        Task InsertArtista(Artista artista);

        Task UpdateArtista(Artista artista);

        Task<bool> DeleteArtista(Artista artista);
    }
}
