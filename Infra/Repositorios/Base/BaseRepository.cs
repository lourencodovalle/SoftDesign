using Domain.Interfaces.Repository.Base;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected SoftDesignContext _db;
        protected DbSet<T> _dbSet;

        public BaseRepository(SoftDesignContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<T> AdicionarAsync(T entidade, CancellationToken cancellationToken)
        {
            await _db.Set<T>().AddAsync(entidade, cancellationToken);
            return entidade;
        }

        public async Task<T> AtualizarAsync(T entidade)
        {
            await Task.Yield();
            _db.Update(entidade);
            return entidade;
        }

        public async Task DeletarAsync(T entidade)
        {
            await Task.Yield();
            _db.Set<T>().Remove(entidade);
        }

        public virtual async Task<List<T>> ObterAsync(CancellationToken cancellationToken)
        {
            return await _db.Set<T>().ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<T> ObterPorIdAsync(object id, CancellationToken cancellationToken)
        {
            T result = await _db.Set<T>().FindAsync(new object[] { id }, cancellationToken).ConfigureAwait(false);
            return result;
        }

        public async Task<int> CommitAsync()
        {
            var retorno = await _db.SaveChangesAsync().ConfigureAwait(false);
            return retorno;
        }
    }
}
