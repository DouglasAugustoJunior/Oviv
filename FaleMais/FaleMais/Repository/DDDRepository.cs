using FaleMais.Domain;
using FaleMais.Repository.Interface;
using FaleMais.Infrastructure.Database;

namespace FaleMais.Repository
{
    public class DDDRepository : BaseRepository<DDD>, IDDDRepository
    {
        public DDDRepository(IFaleMaisDbContext context): base(context) { }

        public bool ValidarExistenciaDeTarifaComDDD(int id) =>
            Context.CustoChamada.Any(_ =>
                (_.DestinoId == id || _.OrigemId == id)
                && !_.DataDelecao.HasValue);

        public bool VerificarSeJaExiste(string ddd) =>
            Context.DDD.Any(_ => _.Nome.Equals(ddd) && !_.DataDelecao.HasValue);
    }
}
