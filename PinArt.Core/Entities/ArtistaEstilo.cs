using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Core.Entities
{
    public class ArtistaEstilo
    {
        public int ArtistaId { get; set; }
        public Artista Artista { get; set; }

        public int EstiloId { get; set; }
        public Estilo Estilo { get; set; }

    }
}
