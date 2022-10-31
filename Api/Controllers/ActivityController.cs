using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Service.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyCors")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _service;

        public ActivityController(IActivityService _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActivityDTO>>> GetActivities()
        {
            var response = new List<ActivityDTO>();
            try
            {
                response.AddRange(await _service.GetActivities());

                if (response == null)
                {
                    return NotFound();
                }
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }

            return Ok(response);
        }
    }
}
