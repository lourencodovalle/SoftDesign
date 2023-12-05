namespace Domain.Interfaces.Repository.Base
{
    public interface IBaseRepository<T>
    {
        Task<T> AdicionarAsync(T entidade, CancellationToken cancellationToken);
        Task<T> AtualizarAsync(T entidade);
        Task DeletarAsync(T entidade);
        Task<List<T>> ObterAsync(CancellationToken cancellationToken);
        Task<T> ObterPorIdAsync(object id, CancellationToken cancellationToken);
        Task<int> CommitAsync();
    }
}
