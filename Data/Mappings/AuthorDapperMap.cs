using Dapper.FluentMap.Dommel.Mapping;
using Domain.Entities;

namespace Data.Mappings
{
    public class AuthorDapperMap : DommelEntityMap<Autor>
    {
        public AuthorDapperMap()
        {
            ToTable("Autor");
            Map(p => p.Id).IsKey();
        }
    }
}