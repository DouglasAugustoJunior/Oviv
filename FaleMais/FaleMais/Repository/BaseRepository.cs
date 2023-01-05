using Microsoft.EntityFrameworkCore;
using Domain;
using Infrastructure.Database;
using Repository.Interface;

namespace Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntidadeBase
    {
        public readonly IFaleMaisDbContext Context;

        public BaseRepository(IFaleMaisDbContext context) =>
            Context = context;

        public void Cadastrar(TEntity entidade)
        {
            Context.Set<TEntity>().Add(entidade);
            Context.SaveChanges();
        }

        public void Atualizar(TEntity entidade)
        {
            Context.SetModified(entidade);
            Context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var entidadeParaDeletar = BuscarPorId(id);
            if (entidadeParaDeletar == null)
                throw new InvalidOperationException("ID inválido para deletar");
            entidadeParaDeletar.AdicionarDataDelecao();
            Atualizar(entidadeParaDeletar);
        }

        public TEntity? BuscarPorId(int id) =>
            Context
                .Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefault(entidade => entidade.Id == id);

        public List<TEntity> Listar() =>
            Context
                .Set<TEntity>()
                .Where(entity => !entity.DataDelecao.HasValue)
                .ToList();
    }
}
