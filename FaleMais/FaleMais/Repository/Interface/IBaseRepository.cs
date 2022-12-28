using FaleMais.Domain;

namespace FaleMais.Repository.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : EntidadeBase
    {
        void Cadastrar(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Deletar(int id);
        TEntity? BuscarPorId(int id);
        List<TEntity> Listar();
    }
}
