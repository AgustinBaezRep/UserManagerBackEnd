using Model.DTO;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> GetUserById(int id);
        public Task<bool> CrateUser(UserViewModel user);
        public Task<bool> UpdateUser(UserViewModel user);
        public Task<bool> DeleteUser(int id);
        public Task<List<CountriesDTO>> GetCountries();
    }
}
