using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IList<User> Get();
        User GetById(int id);
        void Post(User user);
        void Put(User user);
        void Delete(User user);
       
    }
}
