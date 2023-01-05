using Domain.DTO;

namespace Service.Interface
{
    public interface ICalcularService
    {
        IResult Calcular(CalculosDTO calculos);
    }
}