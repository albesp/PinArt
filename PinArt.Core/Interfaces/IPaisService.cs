using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinArt.Core.Interfaces
{
    public interface IPaisService
    {
        Task<IEnumerable<Pais>> GetPaises();
    }
}
