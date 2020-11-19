using PinArt.Core.Entities;
using PinArt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinArt.Core.Services
{
    public class PaisService : IPaisService
    {
        private readonly IUnitOfWork _UoW;

        public PaisService(IUnitOfWork unitOfWork)
        {
            _UoW = unitOfWork;
        }

        public async Task<IEnumerable<Pais>> GetPaises()
        {
            var Paises = await _UoW.Paises.GetAll();

            return Paises;
        }
    }
}
