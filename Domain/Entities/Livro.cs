namespace Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Titulo { get; set; }
        public int AnoPublicacao { get; set; }

        public virtual Autor Autor { get; set; }

    }
}