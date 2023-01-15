using SolaryEnergia.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password  { get; set; }
        public Permissoes Role { get; set; }

        public User() { }

        public User(int id, string nome, string email, string password, Permissoes role)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
