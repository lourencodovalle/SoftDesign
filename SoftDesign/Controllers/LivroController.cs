using Domain.Dtos.Livro;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace SoftDesignApi.Controllers
{

    /// <summary>
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {

        private readonly ILivroService _livroService;

        /// <summary>
        /// Constructor
        /// </summary>
        public LivroController(ILivroService livroService)
        {
            _livroService = livroService ?? throw new ArgumentException(nameof(ILivroService));
        }

        /// <summary>
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _livroService.ObterLivrosAsync(cancellationToken);
            return StatusCode(result.FirstOrDefault().Status.GetHashCode(), result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _livroService.ObterLivroAsync(id, cancellationToken);
            return StatusCode(result.Status.GetHashCode(), result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CadastroLivroDto livro, CancellationToken cancellationToken)
        {
            var result = await _livroService.AdicionarLivroAsync(livro, cancellationToken);
            return StatusCode(result.Status.GetHashCode(), result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AtualizacaoLivroDto livro, CancellationToken cancellationToken)
        {
            var result = await _livroService.AtualizarLivroAsync(livro, cancellationToken);
            return StatusCode(result.Status.GetHashCode(), result);
        }

        [HttpPatch]
        public async Task<ActionResult> Patch([FromBody] AtualizacaoLivroDto livro, CancellationToken cancellationToken)
        {
            var result = await _livroService.AtualizarLivroAsync(livro, cancellationToken);
            return StatusCode(result.Status.GetHashCode(), result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _livroService.RemoverLivroAsync(id, cancellationToken);
            return StatusCode(result.Status.GetHashCode(), result);
        }
    }
}

