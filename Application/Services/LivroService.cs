using Azure.Core;
using Domain.Dtos.Autor;
using Domain.Dtos.Livro;
using Domain.Entidades;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using System.Net;

namespace Application.Services
{
    public class LivroService : ILivroService
    {
        private ILivroRepository _livroRepository;
        private IAutorService _autorService;

        public LivroService(ILivroRepository livroRepository, IAutorService autorService)
        {
            _livroRepository = livroRepository;
            _autorService = autorService;

        }

        public async Task<LivroDto> AtualizarLivroAsync(AtualizacaoLivroDto request, CancellationToken ct)
        {            
            var autor = await _autorService.ObterAutorAsync(request.IdAutor, ct);
            if(autor == null)
                return new LivroDto { Status = autor.Status, Message = autor.Message };

            var livro = await _livroRepository.ObterLivroAsync(request.IdLivro, ct);

            livro.AtualizarLivro(request.Titulo, request.DataLancamento, request.IdAutor);
            await _livroRepository.CommitAsync();

            return new LivroDto { Status = HttpStatusCode.NoContent };
        }

        public async Task<LivroDto> AdicionarLivroAsync(CadastroLivroDto request, CancellationToken ct)
        {
            var autor = await _autorService.ObterAutorAsync(request.IdAutor, ct);
            if (autor == null)
                return new LivroDto { Status = autor.Status, Message = autor.Message };

            var novoLivro = new Livro(request.Titulo, request.DataLancamento, request.IdAutor);
            
            await _livroRepository.AdicionarAsync(novoLivro, ct);
            await _livroRepository.CommitAsync();

            var responseDto = new LivroDto
            {
                Titulo = novoLivro.Titulo,
                DataLancamento = novoLivro.DataLancamento,
                Status = HttpStatusCode.Created
            };

            return responseDto;
        }

        public async Task<LivroDto> ObterLivroAsync(Guid idLivro, CancellationToken ct)
        {
            var livro = await _livroRepository.ObterLivroAsync(idLivro, ct);
            if (livro == null)
                return new LivroDto { Status = HttpStatusCode.NotFound, Message = "Livro não encontrado" };

            var livrosResponse = new LivroDto
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor.Nome,
                DataLancamento = livro.DataLancamento,
            };

            return livrosResponse;
        }

        public async Task<List<LivroDto>> ObterLivrosAsync(CancellationToken ct)
        {
            var listaLivrosResponse = new List<LivroDto>();
            var livros = await _livroRepository.ObterAsync(ct);

            if (livros.Any() || livros == null)
                return new List<LivroDto> {
                    new LivroDto { Status = HttpStatusCode.NotFound, Message = "Livros não encontrados" }
                };

            livros.ForEach(l => listaLivrosResponse.Add(
                new LivroDto
                {
                    Titulo = l.Titulo,
                    Autor = l.Autor.Nome,
                    DataLancamento = l.DataLancamento,
                })
            );

            return listaLivrosResponse;
        }

        public async Task<LivroDto> RemoverLivroAsync(Guid idLivro, CancellationToken ct)
        {
            var livro = await _livroRepository.ObterLivroAsync(idLivro, ct);
            await _livroRepository.DeletarAsync(livro);
            await _livroRepository.CommitAsync();

            return new LivroDto { Status = HttpStatusCode.NoContent };
        }

        private async Task<bool> ValidarAutor(Guid idAutor, CancellationToken ct)
        {
            var autor = await _autorService.ObterAutorAsync(idAutor, ct);
            if (autor.Status != HttpStatusCode.OK)
                return false;

            return true;
        }
    }
}
