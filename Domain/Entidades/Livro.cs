namespace Domain.Entidades
{
    public class Livro
    {
        public Livro() { }
        public Livro(string titulo, DateTime dataLancamento, Guid idAutor)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            DataLancamento = dataLancamento;
            IdAutor = idAutor;
        }

        public Guid Id { get; private set; }
        public string Titulo { get; private set; }        
        public DateTime DataLancamento { get; private set; }


        #region Foreign Keys

        public Guid IdAutor { get; private set; }
        public Autor Autor { get; set; }

        #endregion

        public void AtualizarLivro(string titulo, DateTime dataLancamento, Guid idAutor)
        {
            Titulo = titulo;
            DataLancamento = dataLancamento;
            IdAutor = idAutor;
        }
    }
}
