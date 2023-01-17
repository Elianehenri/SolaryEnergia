using SolaryEnergia.Domain.Enuns;
using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Permissoes Role { get; set; }

        public UserDto()
        {
        }

        public UserDto(User user)
        {
            Id = user.Id;
            Nome = user.Nome;
            Email = user.Email;
            Password = user.Password;
            Role = user.Role;
        }
    }
}
