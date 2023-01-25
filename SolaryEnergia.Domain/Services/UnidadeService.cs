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
    public class UnidadeService : IUnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeService(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public void Delete(int id)
        {
            var unidade = _unidadeRepository.GetById(id);
            _unidadeRepository.Delete(unidade);
        }

        public IList<UnidadeDto> Get()
        {
            return _unidadeRepository.Get()
                .Select(u => new UnidadeDto(u))
                .ToList();
        }

        public UnidadeDto GetById(int id)
        {
            var undDb = _unidadeRepository.GetById(id);
            if (undDb == null)
            {
                throw new UnidadeInativaException("unidade nao cadastrada!");
            }
            
            return new UnidadeDto(_unidadeRepository.GetById(id));
        }

        public void Post(UnidadeDto unidade)
        {
     

            _unidadeRepository.Post(new Unidade(unidade));
        }

        public void Put(UnidadeDto unidade)
        {
            Unidade unidadeDb =_unidadeRepository.GetById(unidade.Id);

            unidadeDb.Update(unidade);
            _unidadeRepository.Put(unidadeDb);
        }
    }
}
