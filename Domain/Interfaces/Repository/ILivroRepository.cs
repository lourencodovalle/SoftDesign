using Domain.Entidades;
using Domain.Interfaces.Repository.Base;

namespace Domain.Interfaces.Repository
{
    public interface ILivroRepository : IBaseRepository<Livro>
    {
        Task<Livro> ObterLivroAsync(Guid id, CancellationToken cancellationToken);

    }
}
