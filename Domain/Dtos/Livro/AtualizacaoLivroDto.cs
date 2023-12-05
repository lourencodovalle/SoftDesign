namespace Domain.Dtos.Livro
{
    public class AtualizacaoLivroDto : LivroDto
    {
        public Guid IdLivro { get; set; }
        public Guid IdAutor { get; set; }
    }
}
