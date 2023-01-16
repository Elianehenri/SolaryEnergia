using SolaryEnergia.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Models
{
    public class Geracao
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public  int Kw  { get; set; }
        public int UnidadeId { get; set; }
        public virtual Unidade Unidade { get; set; }

        public Geracao() { }

        public Geracao(int id, string data, int kw)
        {
            Id = id;
            Data = data;
            Kw = kw;
        }

        public Geracao(GeracaoDto geracao)
        {
            Id = geracao.Id;
            Data = geracao.Data;
            Kw = geracao.Kw;
            UnidadeId = geracao.UnidadeId;
        }
        public void Update(GeracaoDto geracao)
        {
            Data = geracao.Data;
            Kw = geracao.Kw;
            UnidadeId = geracao.UnidadeId;
        }
    }
}
