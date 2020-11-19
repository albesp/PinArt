using PinArt.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PinArt.Core.Interfaces
{
    public interface IPaisRepository
    {
        Task<IEnumerable<Pais>> GetAll();
    }
}
