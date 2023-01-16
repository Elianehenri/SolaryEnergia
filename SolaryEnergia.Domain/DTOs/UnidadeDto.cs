using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.DTOs
{
    public class UnidadeDto
    {

        public int Id { get; set; }
        public string Apelido { get; set; }
        public string Local { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public bool IsActive { get; set; }

        public UnidadeDto()
        {
        }

        public UnidadeDto(Unidade unidade)
        {
            Id = unidade.Id;
            Apelido = unidade.Apelido;
            Local = unidade.Local;
            Marca=unidade.Marca;
            Modelo = unidade.Modelo;
            IsActive = unidade.IsActive;
        }
    }
}
