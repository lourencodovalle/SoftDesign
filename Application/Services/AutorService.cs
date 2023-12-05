using Domain.Dtos.Autor;
using Domain.Entidades;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using System.Net;

namespace Application.Services
{
    public class AutorService : IAutorService
    {
        private IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<AutorDto> AtualizarLivroAsync(AtualizacaoAutorDto request, CancellationToken ct)
        {
            var autor = await _autorRepository.ObterPorIdAsync(request.IdAutor, ct);

            autor.AtualizarAutor(request.Nome);
            await _autorRepository.CommitAsync();

            return new AutorDto { Status = HttpStatusCode.NoContent };
        }

        public async Task<AutorDto> AdicionarAutorAsync(CadastroAutorDto request, CancellationToken ct)
        {
            var novoAutor = new Autor(request.Nome);

            await _autorRepository.AdicionarAsync(novoAutor, ct);
            await _autorRepository.CommitAsync();

            var responseDto = new AutorDto
            {
                Nome = novoAutor.Nome,
                Status = HttpStatusCode.Created
            };

            return responseDto;
        }

        public async Task<AutorDto> ObterAutorAsync(Guid idAutor, CancellationToken ct)
        {
            var autor = await _autorRepository.ObterPorIdAsync(idAutor, ct);
            if (autor == null)
                return new AutorDto { Status = HttpStatusCode.NotFound, Message = "Autor não encontrado" };

            return new AutorDto
            {
                Nome = autor.Nome
            };
        }

        public async Task<List<AutorDto>> ObterAutoresAsync(CancellationToken ct)
        {
            var listaAutoresResponse = new List<AutorDto>();
            var autores = await _autorRepository.ObterAsync(ct);

            if (autores.Any() || autores == null)
                return new List<AutorDto> {
                    new AutorDto { Status = HttpStatusCode.NotFound, Message = "Autores não encontrados" }
                };

            autores.ForEach(a => listaAutoresResponse.Add(
                new AutorDto
                {
                    Nome = a.Nome
                })
            );

            return listaAutoresResponse;
        }

        public async Task<AutorDto> RemoverAutorAsync(Guid idAutor, CancellationToken ct)
        {
            var autor = await _autorRepository.ObterPorIdAsync(idAutor, ct);
            await _autorRepository.DeletarAsync(autor);
            await _autorRepository.CommitAsync();

            return new AutorDto { Status = HttpStatusCode.NoContent };
        }
    }
}
