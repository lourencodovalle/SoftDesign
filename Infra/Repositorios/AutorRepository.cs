using Domain.Entidades;
using Domain.Interfaces.Repository;
using Infra.Contexto;
using Infra.Repositorios.Base;

namespace Infra.Repositorios
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(SoftDesignContext db) : base(db) { }
    }
}
