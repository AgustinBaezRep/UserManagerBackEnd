using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Common
{
    public static class CommonServices
    {
        public static int AssignCountryIdIfDoesExist(int id, UserManagerContext context)
        {
			try
			{
                int? paisResidencia = context.Pais.FirstOrDefault(p => p.Id == id)?.Id;
                if (paisResidencia == null)
                    throw new Exception($"ID de pais {id} no existente");

                return paisResidencia.Value;
            }
			catch (Exception ex)
			{
                throw new Exception(ex.Message);
			}
        }
    }
}
