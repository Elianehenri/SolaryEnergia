using SolaryEnergia.Domain.DTOs;
using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IList<UserDto> Get();
        UserDto GetById(int id);
        void Post(UserDto user);
        void Put(UserDto user);
        void Delete(int id);
        Tuple<string, string, string> GetUser(LoginDto login);
        Tuple<string, string> RefreshToken(string token, string refreshToken);
    }
}

