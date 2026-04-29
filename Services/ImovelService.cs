using GestorAlugueis.Data;
using GestorAlugueis.Entities;
using GestorAlugueis.Repositories;

namespace GestorAlugueis.Services
{
    public class ImovelService
    {
        private readonly ImovelRepository _repository;

        public ImovelService(ImovelRepository repository)
        {
            _repository = repository;
        }

        public void Criar(Imovel imovel)
        {
            if(imovel.ValorAluguel <= 0)
            {
                throw new ArgumentException("O valor do aluguel deve ser maior que zero.");
            }
            _repository.Adicionar(imovel);
        }
        public List<Imovel> ObterTodos()
        {
            return _repository.ObterTodos();
        }


    }
}