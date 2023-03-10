using Microsoft.IdentityModel.Tokens;
using SolaryEnergia.Domain.DTOs;
using SolaryEnergia.Domain.Exceptions;
using SolaryEnergia.Domain.Interfaces.Repositories;
using SolaryEnergia.Domain.Interfaces.Services;
using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Services
{
    public class GeracaoService : IGeracaoService
    {
        private readonly IGeracaoRepository _geracaoRepository;
        private readonly IUnidadeRepository _unidadeRepository;

        public GeracaoService(IGeracaoRepository geracaoRepository, IUnidadeRepository unidadeRepository)
        {
            _geracaoRepository = geracaoRepository;
            _unidadeRepository = unidadeRepository;
        }

        public void Delete(int id)
        {
            Geracao geracaoDb = _geracaoRepository.GetById(id);
            _geracaoRepository.Delete(geracaoDb);
        }

        public IList<GeracaoDto> Get()
        {
            return _geracaoRepository.Get()
                .Select(g => new GeracaoDto(g))
                .ToList();
        }

        public GeracaoDto GetById(int id)
        {
            var geracaoDb = _geracaoRepository.GetById(id);

            if (geracaoDb == null) 
            {
                throw new GeracaoNaoCadastradaException("Geraçao nao cadastrada!");
            }

            return new GeracaoDto(_geracaoRepository.GetById(id));
        }

      
        public void Post(GeracaoDto geracao)
        {
            if (UnidadeEhAtiva(geracao.UnidadeId))
            
                throw new UnidadeInativaException("Unidade Inativa");

                if (DataCadastrada(geracao))
                    throw new DataCadastradaException("Data ja cadastrada no sistema!");
                _geracaoRepository.Post(new Geracao(geracao));
           
            
        }
        private bool DataCadastrada(GeracaoDto geracao)
        {
            return _geracaoRepository.Get()
                .Any(g => g.Data == geracao.Data && g.UnidadeId == geracao.UnidadeId);
        }

        private bool UnidadeEhAtiva(int idUnidade)
        {
            var unidade = _unidadeRepository.GetById(idUnidade);
            return(unidade.IsActive != true);
           
        }

        public void Put(GeracaoDto geracao)
        {
            Geracao geracaoDb = _geracaoRepository.GetById(geracao.Id);
            geracaoDb.Update(geracao);

            _geracaoRepository.Put(geracaoDb);
        }
    }
}
