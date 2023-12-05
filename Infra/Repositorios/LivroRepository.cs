using Domain.Entidades;
using Domain.Interfaces.Repository;
using Infra.Contexto;
using Infra.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {

        public LivroRepository(SoftDesignContext db) : base(db) { }
        public async Task<Livro> ObterLivroAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _db.Set<Livro>()
                .Include(a => a.Autor)
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
