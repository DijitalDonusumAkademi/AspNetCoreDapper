using System.Collections.Generic;

namespace Domain.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}