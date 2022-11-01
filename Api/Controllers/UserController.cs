using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.ViewModel;
using Service.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyCors")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            var response = new List<UserDTO>();
            try
            {
                response.AddRange(await _service.GetUsers());

                if (response.Count == 0)
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

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var response = new UserDTO();
            try
            {
                response = await _service.GetUserById(id);

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

        [HttpPost("CreateUser")]
        public async Task<ActionResult<bool>> CreateUser([FromBody] UserViewModel user)
        {
            try
            {
                bool response = await _service.CrateUser(user);

                if (response == false)
                {
                    return BadRequest("Ocurrio un error al agregar el usuario");
                }
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }

            return Ok("Usuario agregado de manera exitosa");
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<bool>> UpdateUser([FromBody] UserViewModel user)
        {
            try
            {
                bool response = await _service.UpdateUser(user);

                if (response == false)
                {
                    return BadRequest("Ocurrio un error al modificar el usuario");
                }
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }

            return Ok("Usuario modificado de manera exitosa");
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            try
            {
                bool response = await _service.DeleteUser(id);

                if (response == false)
                {
                    return BadRequest("Error al eliminar el usuario");
                }
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }

            return Ok("Usuario eliminado de manera exitosa");
        }

        [HttpGet("GetCountries")]
        public async Task<ActionResult<List<CountriesDTO>>> GetCountries()
        {
            var response = new List<CountriesDTO>();
            try
            {
                response.AddRange(await _service.GetCountries());

                if (response.Count == 0)
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