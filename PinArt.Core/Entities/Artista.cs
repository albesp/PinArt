using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PinArt.Core.Entities
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Biografia { get; set; }

        public int PaisId { get; set; }
        public Pais Pais { get; set; } //  Navigation Property

        //public virtual ICollection<Obra> Obras { get; set; }
        public ICollection<Obra> Obras { get; set; }
        public Artista()
        {
            Obras = new Collection<Obra>();
        }

        public ICollection<ArtistaEstilo> ArtistasEstilos { get; set; }
    }
}