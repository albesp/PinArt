using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Core.Entities
{
    public class Obra
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fecha { get; set; }

        public int ArtistaId { get; set; }
        public Artista Artista { get; set; } // Navigation Property

        public int TecnicaId { get; set; }
        public Tecnica Tecnica { get; set; } // Navigation Property
        
    }
}
