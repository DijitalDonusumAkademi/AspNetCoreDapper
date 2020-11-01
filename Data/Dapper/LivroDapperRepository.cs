using System.Collections.Generic;
using Dapper;
using System.Linq;
using Data.Dapper.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;

namespace Data.Dapper
{
    public class LivroDapperRepository : DapperRepositoryBase<Livro>,ILivroDapperRepository
    {
        public LivroDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override IEnumerable<Livro> GetAll() => 
            conn.Query<Livro,Autor,Livro>(
            @"Select * From Livro INNER JOIN Autor ON Livro.AutorId = AutorId",
            map:(livro,autor) =>
                {
                    livro.Autor = autor;
                    return livro;
                });

        public override Livro GetById(int? id) =>
        conn.Query<Livro,Autor,Livro>(
        @"SELECT TOP(1) * FROM Livro INNER JOIN Aıtor ON Livro.AutorId = Autor.Id Where Livro.Id = @livroId",
        map:(livro,autor) =>
        {
            livro.Autor = autor;
            return livro;
        },
        param: new {livroId = id}).FirstOrDefault();
    }
}