using FaleMais.Domain.DTO;

namespace FaleMais.Service.Interface
{
    public interface ICalcularService
    {
        IResult Calcular(CalculosDTO calculos);
    }
}