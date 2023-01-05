using Domain;

namespace Repository.Interface
{
    public interface IDDDRepository : IBaseRepository<DDD>
    {
        bool ValidarExistenciaDeTarifaComDDD(int id);
        bool VerificarSeJaExiste(string ddd);
    }
}
