using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Core.Entities
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Artista> Artistas { get; set; }

        public Pais()
        {
            Artistas = new HashSet<Artista>();            
        }
    }
}
