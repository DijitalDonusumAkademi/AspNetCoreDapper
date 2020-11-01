using Data.Dapper.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;

namespace Data.Dapper
{
    public class AuthorDapperRepository : DapperRepositoryBase<Autor>,IAuthorDapperRepository
    {
        public AuthorDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}