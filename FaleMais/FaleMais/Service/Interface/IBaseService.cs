using Domain;

namespace Service.Interface
{
    public interface IBaseService<TEntity> where TEntity : EntidadeBase
    {
        IResult Deletar(int id);
    }
}
