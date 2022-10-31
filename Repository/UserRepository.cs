using Data;
using Microsoft.EntityFrameworkCore;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository
    {
        private readonly UserManagerContext context;

        public UserRepository(UserManagerContext context)
        {
            this.context = context;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            List<UserDTO> response = new List<UserDTO>();
            try
            {
                var users = await context.Usuario.ToListAsync();
                users.ForEach(u =>
                {
                    response.Add(new UserDTO()
                    {
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        CorreoElectronico = u.CorreoElectronico,
                        FechaNacimiento = u.FechaNacimiento,
                        Telefono = (int)u.Telefono,
                        PaisResidencia = context.Pais.First(p => p.Id == u.IdPaisResidencia).Descripcion
                    });
                });
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el listado de usuarios");
            }

            return response;
        }
    }
}
