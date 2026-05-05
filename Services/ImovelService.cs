using GestorAlugueis.DTOs;
using GestorAlugueis.Repositories;
using GestorAlugueis.Entities;
using System;
using System.Collections.Generic;
using GestorAlugueis.Controllers;
using GestorAlugueis.Services;


namespace GestorAlugueis.Services
{
    public class ImovelService
    {
        private readonly ImovelRepository _repository;

        public ImovelService(ImovelRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Imovel> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public Imovel ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public int Criar(ImovelCreateDto dto)
        {
            var imovel = new Imovel(dto.Endereco, dto.ValorAluguel, dto.Disponivel);
            _repository.Criar(imovel);
            return imovel.Id;
        }

        public void Atualizar(int id, ImovelCreateDto dto)
        {
            var imovelExistente = _repository.ObterPorId(id);
            if (imovelExistente == null)
            {
                throw new Exception("Imóvel não encontrado");
            }

            imovelExistente.Endereco = dto.Endereco;
            imovelExistente.ValorAluguel = dto.ValorAluguel;
            imovelExistente.Disponivel = dto.Disponivel;

            _repository.Atualizar(imovelExistente);
        }

        public void Deletar(int id)
        {
            _repository.Deletar(id);
        }      


    }
}