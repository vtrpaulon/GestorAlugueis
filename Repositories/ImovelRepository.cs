using GestorAlugueis.Data;
using GestorAlugueis.Entities;
using Microsoft.EntityFrameworkCore;    
using System;

namespace GestorAlugueis.Repositories
{
    public class ImovelRepository
    {
        private readonly ApplicationDbContext _context;

        public ImovelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Imovel imovel)
        {
            _context.Imoveis.Add(imovel);
            _context.SaveChanges();
        }

        public List<Imovel>  ObterTodos()
        {
            return _context.Imoveis.ToList();
        }

    }
}