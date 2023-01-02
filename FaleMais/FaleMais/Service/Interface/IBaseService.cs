using FaleMais.Domain;

namespace FaleMais.Service.Interface
{
    public interface IBaseService<TEntity> where TEntity : EntidadeBase
    {
        IResult Deletar(int id);
    }
}
