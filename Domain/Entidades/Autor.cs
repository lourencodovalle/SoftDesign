using Domain.Dtos.Base;

namespace Domain.Entidades
{
    public class Autor
    {
        public Autor() { }
        public Autor(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }


        public IEnumerable<Livro> Livros { get; private set; }

        public void AtualizarAutor(string nome)
        {
            Nome = nome;
        }
    }
}
