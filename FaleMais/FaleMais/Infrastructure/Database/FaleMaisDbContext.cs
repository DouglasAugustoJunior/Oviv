using FaleMais.Domain;
using Microsoft.EntityFrameworkCore;

namespace FaleMais.Infrastructure.Database
{
    public class FaleMaisDbContext : DbContext, IFaleMaisDbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<DDD> DDD { get; set; }
        public DbSet<CustoChamada> CustoChamada { get; set; }
        public DbSet<Plano> Plano { get; set; }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("DataSource=FaleMaisDb.db;Cache=Shared");
    }
}
