using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.DTOs
{
    public class GeracaoDto
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int Kw { get; set; }
        public int UnidadeId { get; set; }

        public GeracaoDto() { }

        public GeracaoDto(Geracao geracao)
        {
            Id = geracao.Id;
            Data = geracao.Data;
            Kw = geracao.Kw;
            UnidadeId = geracao.UnidadeId;
        }
    }
}
