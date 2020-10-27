using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PinArt.Core.Entities
{
    public class Tecnica
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Obra> Obras { get; set; }
        public Tecnica()
        {
            Obras = new Collection<Obra>();
        }
    }
}
