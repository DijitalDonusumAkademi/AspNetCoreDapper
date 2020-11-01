using Dapper.FluentMap.Dommel.Mapping;
using Domain.Entities;

namespace Data.Mappings
{
    public class LivroDapperMap : DommelEntityMap<Livro>
    {
        public LivroDapperMap()
        {
            ToTable("Livro");
            Map(p => p.Id).IsKey().IsIdentity();
        }
    }
}