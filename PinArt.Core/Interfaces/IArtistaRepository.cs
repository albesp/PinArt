using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinArt.Core.Interfaces
{
    public interface IArtistaRepository
    {
        Task<IEnumerable<Artista>> GetAll();
        Task<Artista> GetById(int id);
        void Add(Artista artista);
        void Update(Artista artista);
        void Remove(Artista artista);
    }
}
