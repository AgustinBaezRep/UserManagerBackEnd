using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Actividad
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public string Actividad1 { get; set; }
    }
}
