using GestorAlugueis.DTOs;
using GestorAlugueis.Repositories;
using GestorAlugueis.Entities;
using System.Linq;


namespace GestorAlugueis.Services
{
    public class ImovelService
    {
        private readonly ImovelRepository _repository;

        public ImovelService(ImovelRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ImovelDto> ObterTodos()
        {
            return _repository.ObterTodos()
            .Select(i => new ImovelDto
            {
                Id = i.Id,
                Endereco = i.Endereco,
                ValorAluguel = i.ValorAluguel,
                Disponivel = i.Disponivel
            });
        }

        public ImovelDto? ObterPorId(int id)
        {

            var i = _repository.ObterPorId(id);
            if (i == null)
            return null;

            return new ImovelDto
            {
                Id = i.Id,
                Endereco = i.Endereco,
                ValorAluguel = i.ValorAluguel,
                Disponivel = i.Disponivel
            };
        }

        public int Criar(ImovelDto dto)
        {
            if (dto.ValorAluguel <= 0)
            throw new ArgumentException("Valor do aluguel deve ser maior que zero");

            var imovel = new Imovel(dto.Endereco, dto.ValorAluguel, dto.Disponivel);
            _repository.Criar(imovel);
            return imovel.Id;
        }

        public void Atualizar(int id, ImovelDto dto)
        {
            var imovelExistente = _repository.ObterPorId(id);
            if (imovelExistente == null)
            {
                throw new KeyNotFoundException("Imóvel não encontrado");
            }

            imovelExistente.Endereco = dto.Endereco;
            imovelExistente.ValorAluguel = dto.ValorAluguel;
            imovelExistente.Disponivel = dto.Disponivel;

            _repository.Atualizar(imovelExistente);
        }

        public void Deletar(int id)
        {
            var imovel = _repository.ObterPorId(id);
            if (imovel == null)
                throw new KeyNotFoundException("Imóvel não encontrado");
            _repository.Deletar(id);
        }      


    }
}