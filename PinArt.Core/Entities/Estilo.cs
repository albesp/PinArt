using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Core.Entities
{
    public class Estilo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<ArtistaEstilo> ArtistaEstilos { get; set; }
    }
}
