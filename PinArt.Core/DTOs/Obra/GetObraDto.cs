using PinArt.Core.DTOs.Tecnica;
using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Core.DTOs.Obra
{
    public class GetObraDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fecha { get; set; }

        //public int ArtistaId { get; set; }
        //public GetArtistaDto Artista { get; set; } // Navigation Property        
        public GetTecnicaDto Tecnica { get; set; } // Navigation Property
    }
}
