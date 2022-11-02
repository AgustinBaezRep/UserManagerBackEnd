using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long? Telefono { get; set; }
        public string PaisResidencia { get; set; }
        public bool RecibirInformacion { get; set; }
    }
}
