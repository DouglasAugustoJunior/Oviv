using FaleMais.Domain;
using Microsoft.EntityFrameworkCore;

namespace FaleMais.Infrastructure.Database
{
    public interface IFaleMaisDbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<DDD> DDD { get; set; }
        public DbSet<CustoChamada> CustoChamada { get; set; }
        public DbSet<Plano> Plano { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        void SetModified(object entity);
    }
}
