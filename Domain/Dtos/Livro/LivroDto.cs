using Domain.Dtos.Base;

namespace Domain.Dtos.Livro
{
    public class LivroDto : BaseDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
