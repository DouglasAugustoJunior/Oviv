using Domain;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : EntidadeBase
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository) =>
            _repository = repository;

        public virtual IResult Deletar(int id)
        {
            if (id <= 0)
                return Results.BadRequest("ID inválido para deletar");
            _repository.Deletar(id);
            return Results.Ok("Excluído com sucesso!");
        }
    }
}
