using Domain.Dtos.Livro;

namespace Domain.Interfaces.Services
{
    public interface ILivroService
    {
        Task<LivroDto> AtualizarLivroAsync(AtualizacaoLivroDto request, CancellationToken ct);
        Task<LivroDto> AdicionarLivroAsync(CadastroLivroDto request, CancellationToken ct);
        Task<LivroDto> ObterLivroAsync(Guid idLivro, CancellationToken ct);
        Task<List<LivroDto>> ObterLivrosAsync(CancellationToken ct);
        Task<LivroDto> RemoverLivroAsync(Guid idLivro, CancellationToken ct);

    }
}
