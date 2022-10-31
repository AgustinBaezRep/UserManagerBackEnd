using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTO
{
    public class UserDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? Telefono { get; set; }
        public string PaisResidencia { get; set; }
    }
}
