using Data.Models;
using Microsoft.EntityFrameworkCore;
using Model.DTO;
using Model.ViewModel;
using Service.Common;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly UserManagerContext context;
        private readonly IActivityService activityService;

        public UserService(UserManagerContext context, IActivityService activityService)
        {
            this.context = context;
            this.activityService = activityService;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            UserDTO userDTO;
            try
            {
                var u = await context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
                if (u == null) return null;

                userDTO = new UserDTO()
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    CorreoElectronico = u.CorreoElectronico,
                    FechaNacimiento = u.FechaNacimiento,
                    Telefono = u.Telefono,
                    PaisResidencia = context.Pais.First(p => p.Id == u.IdPaisResidencia).Descripcion,
                    RecibirInformacion = u.RecibirInformacion
                };
            }
            catch (Exception)
            {
                throw new Exception($"Error al obtener el usuario de id {id}");
            }

            return userDTO;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            List<UserDTO> response = new List<UserDTO>();
            try
            {
                var users = await context.Usuario.ToListAsync();
                users?.ForEach(u =>
                {
                    response.Add(new UserDTO()
                    {
                        Id = u.Id,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        CorreoElectronico = u.CorreoElectronico,
                        FechaNacimiento = u.FechaNacimiento,
                        Telefono = u.Telefono,
                        PaisResidencia = context.Pais.First(p => p.Id == u.IdPaisResidencia).Descripcion,
                        RecibirInformacion = u.RecibirInformacion
                    });
                });
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el listado de usuarios");
            }

            return response;
        }

        public async Task<bool> CrateUser(UserViewModel user)
        {
            try
            {
                await context.Usuario.AddAsync(new Usuario()
                {
                    Nombre = user.Nombre,
                    Apellido = user.Apellido,
                    CorreoElectronico = user.CorreoElectronico,
                    FechaNacimiento = user.FechaNacimiento,
                    Telefono = user.Telefono,
                    IdPaisResidencia = CommonServices.AssignCountryIdIfDoesExist(user.IdPaisResidencia, context),
                    RecibirInformacion = user.RecibirInformacion
                });

                await context.SaveChangesAsync();
                var userRegistered = await context.Usuario.ToListAsync();
                await activityService.UserActivityRecord(userRegistered.Last().Id, "Creacion de usuario");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(UserViewModel user)
        {
            try
            {
                var u = await context.Usuario.FindAsync(user.Id);

                if (u == null) return false;

                u.Nombre = user.Nombre;
                u.Apellido = user.Apellido;
                u.CorreoElectronico = user.CorreoElectronico;
                u.FechaNacimiento = user.FechaNacimiento;
                u.Telefono = user.Telefono;
                u.IdPaisResidencia = CommonServices.AssignCountryIdIfDoesExist(user.IdPaisResidencia, context);
                u.RecibirInformacion = user.RecibirInformacion;

                await context.SaveChangesAsync();
                await activityService.UserActivityRecord(u.Id, "Actualizacion de usuario");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var u = await context.Usuario.FindAsync(id);

                if (u == null) return false;

                context.Usuario.Remove(u);
                context.SaveChanges();
                await activityService.UserActivityRecord(u.Id, "Eliminacion de usuario");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CountriesDTO>> GetCountries()
        {
            List<CountriesDTO> response = new List<CountriesDTO>();
            try
            {
                var countries = await context.Pais.ToListAsync();
                countries?.ForEach(u =>
                {
                    response.Add(new CountriesDTO()
                    {
                        Id = u.Id,
                        Descripcion = u.Descripcion
                    });
                });
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el listado de paises");
            }

            return response;
        }
    }
}