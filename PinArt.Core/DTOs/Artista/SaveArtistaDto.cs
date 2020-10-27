using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Core.DTOs.Artista
{
    public class SaveArtistaDto
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Biografia { get; set; }
        public int PaisId { get; set; }

    }
}
