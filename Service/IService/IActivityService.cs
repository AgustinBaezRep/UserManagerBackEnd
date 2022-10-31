using Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IActivityService
    {
        Task UserActivityRecord(int id, string activity);
        Task<List<ActivityDTO>> GetActivities();
    }
}
