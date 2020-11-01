using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Data.Mappings;
using Domain.Interfaces.Repositories.Common;
using Dommel;
using Microsoft.Extensions.Configuration;

namespace Data.Dapper.Common
{
    public abstract class DapperRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity:class
    {
        private readonly IConfiguration _configuration;
        protected readonly SqlConnection conn;

        public DapperRepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(c =>
                {
                    c.AddMap(new LivroDapperMap());
                    c.AddMap(new AuthorDapperMap());
                    c.ForDommel();
                });
            }

            conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public void Add(TEntity obj) => conn.Insert(obj);
        

        public virtual TEntity GetById(int? id) => conn.Get<TEntity>(id);



        public virtual IEnumerable<TEntity> GetAll() => conn.GetAll<TEntity>();


        public void Update(TEntity obj) => conn.Update(obj);


        public virtual void Delete(TEntity obj) => conn.Delete(obj);
        

        private bool _disposed = false;

        DapperRepositoryBase()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (Equals(!_disposed))
            {
                conn.Close();
                conn.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}