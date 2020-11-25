using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinArt.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IArtistaRepository Artistas { get; }
        IPaisRepository Paises { get; }
        ISecurityRepository Security { get; }
        Task CompleteAsync();
    }
}
