using Domain.Dtos.Autor;

namespace Domain.Interfaces.Services
{
    public interface IAutorService
    {
        Task<AutorDto> AtualizarLivroAsync(AtualizacaoAutorDto request, CancellationToken ct);
        Task<AutorDto> AdicionarAutorAsync(CadastroAutorDto request, CancellationToken ct);
        Task<AutorDto> ObterAutorAsync(Guid idAutor, CancellationToken ct);
        Task<List<AutorDto>> ObterAutoresAsync(CancellationToken ct);
        Task<AutorDto> RemoverAutorAsync(Guid idAutor, CancellationToken ct);

    }
}
