using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ConsorcioRepositorio : IConsorcioEntidade
    {
        private readonly IDbContext _dbContext;

        public ConsorcioRepositorio(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Adicionar(ConsorcioDomain consorcioDomain)
        {
            var sql = @"INSERT INTO consorcio (descricao, categoria, data, valor, parcelas)
                        VALUES (@descricao, @categoria, @data, @valor, @parcelas)";

            var parameters = new DynamicParameters();
            parameters.Add("descricao", consorcioDomain.Descricao, DbType.String);
            parameters.Add("categoria", consorcioDomain.Categoria, DbType.String);
            parameters.Add("data", consorcioDomain.dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"), DbType.DateTime);
            parameters.Add("valor", consorcioDomain.Valor, DbType.Decimal);
            parameters.Add("parcelas", consorcioDomain.Parcelas, DbType.Int64);

            using var connection = _dbContext.CreateConnection();
            connection.Execute(sql, parameters);
        }

        public void Atualizar(int id, ConsorcioDomain consorcioDomain)
        {
            var sql = @"UPDATE consorcio 
                        SET descricao = @descricao,
                            data = @data,
                            valor = @valor,
                            categoria = @categoria,
                            parcelas = @parcelas
                        WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("descricao", consorcioDomain.Descricao, DbType.String);
            parameters.Add("data", consorcioDomain.dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"), DbType.DateTime);
            parameters.Add("valor", consorcioDomain.Valor, DbType.Decimal);
            parameters.Add("categoria", consorcioDomain.Categoria, DbType.String);
            parameters.Add("parcelas", consorcioDomain.Parcelas, DbType.Int64);

            using var connection = _dbContext.CreateConnection();
            connection.Execute(sql, parameters);
        }

        public void Excluir(int id)
        {
            var sql = "DELETE FROM consorcio WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32); // CORRETO: id é int

            using var connection = _dbContext.CreateConnection();
            connection.Execute(sql, parameters);
        }

        public ConsorcioDomain Buscar(int id)
        {
            var sql = "SELECT * FROM consorcio WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            return connection.QueryFirstOrDefault<ConsorcioDomain>(sql, parameters);
        }


        public List<ConsorcioDomain> BuscarTodos()
        {
            var sql = "SELECT * FROM consorcio";

            using var connection = _dbContext.CreateConnection();

            var lista = connection.Query(sql).ToList();

            var consorcios = lista.Select(row => new ConsorcioDomain(
                (string)row.descricao,
                (DateTime)row.data, // ou row.dataCriacao, depende do nome na tabela
                (double)row.valor,
                (string)row.categoria,
                (int)(row.parcelas ?? 0) // ou trate null se for opcional
            )).ToList();

            return consorcios;
        }

    }
}
