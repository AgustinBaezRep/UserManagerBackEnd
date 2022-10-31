using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
