using Data.Models;
using Microsoft.EntityFrameworkCore;
using Model.DTO;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ActivityService : IActivityService
    {
        private readonly UserManagerContext context;

        public ActivityService(UserManagerContext context)
        {
            this.context = context;
        }

        public async Task UserActivityRecord(int id, string activity)
        {
            try
            {
                await context.Actividad.AddAsync(new Actividad()
                {
                    FechaCreacion = DateTime.Now.Date,
                    IdUsuario = id,
                    Actividad1 = activity
                });
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ActivityDTO>> GetActivities()
        {
            List<ActivityDTO> response = new List<ActivityDTO>();
            try
            {
                var activities = await context.Actividad.ToListAsync();
                activities?.ForEach(a =>
                {
                    response.Add(new ActivityDTO()
                    {
                        FechaActividad = a.FechaCreacion,
                        NombreUsuario = context.Usuario.FirstOrDefault(u => u.Id == a.IdUsuario)?.Nombre ?? "Usuario removido",
                        DetalleActividad = a.Actividad1
                    });
                });
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el listado de actividades");
            }

            return response;
        }

    }
}