using PinArt.Core.DTOs.Estilo;
using PinArt.Core.DTOs.Obra;
using PinArt.Core.DTOs.Pais;
using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PinArt.Core.DTOs.Artista
{
    public class GetArtistaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Biografia { get; set; }

        public GetPaisDto Pais { get; set; }

        public ICollection<GetObraDto> Obras { get; set; }
        public ICollection<GetEstiloDto> Estilos { get; set; }

        public GetArtistaDto()
        {
            Obras = new Collection<GetObraDto>();
            Estilos = new Collection<GetEstiloDto>();
        }
    }
}
