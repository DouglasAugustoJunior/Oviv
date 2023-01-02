using FaleMais.Domain;

namespace FaleMais.Repository.Interface
{
    public interface IDDDRepository : IBaseRepository<DDD>
    {
        bool ValidarExistenciaDeTarifaComDDD(int id);
        bool VerificarSeJaExiste(string ddd);
    }
}
