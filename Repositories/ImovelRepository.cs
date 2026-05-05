using GestorAlugueis.Data;
using GestorAlugueis.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;    
using System;
using System.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GestorAlugueis.Repositories
{
    public class ImovelRepository
    {
       private readonly string _connectionString;

       public ImovelRepository(IConfiguration configuration)
       {
           _connectionString = configuration.GetConnectionString("DefaultConnection");
       }

       private IDbConnection Connection()
       {
           return new SqlConnection(_connectionString);
       }

       //Obter todos os imóveis
         public IEnumerable<Imovel> ObterTodos()
         {
            using var db = Connection();
            return db.Query<Imovel>("SELECT * FROM Imoveis");
         }

        //Obter um imóvel por ID
         public Imovel ObterPorId(int id)
         {
            using var db = Connection();
            return db.QuerySingleOrDefault<Imovel>
            ("SELECT * FROM Imoveis WHERE Id = @Id", new { Id = id });
         }

        //Adicionar um novo imóvel
         public void Criar(Imovel imovel)
            {
                using var db = Connection();
                var sql = 
                "INSERT INTO Imoveis (Endereco, ValorAluguel, Disponivel) VALUES (@Endereco, @ValorAluguel, @Disponivel); SELECT CAST(SCOPE_IDENTITY() as int)";

                var id = db.QuerySingle<int>(sql, imovel);                
            }

        //Atualizar um imóvel existente
         public void Atualizar(Imovel imovel)
         {
            using var db = Connection();
            var sql = "UPDATE Imoveis SET Endereco = @Endereco, ValorAluguel = @ValorAluguel, Disponivel = @Disponivel WHERE Id = @Id";
            db.Execute(sql, new 
            { 
                Endereco = imovel.Endereco, 
                ValorAluguel = imovel.ValorAluguel, 
                Disponivel = imovel.Disponivel, 
                Id = imovel.Id });
         }

        //Excluir um imóvel
         public void Deletar(int id)
         {
            using var db = Connection();
            var sql = "DELETE FROM Imoveis WHERE Id = @Id";
            db.Execute(sql, new { Id = id });
         }



    }
}