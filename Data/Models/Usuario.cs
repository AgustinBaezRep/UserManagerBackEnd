using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long Telefono { get; set; }
        public int IdPaisResidencia { get; set; }
        public bool RecibirInformacion { get; set; }

        public virtual Pais IdPaisResidenciaNavigation { get; set; }
    }
}
